#include <WiFi.h>
#include <PubSubClient.h>
#include <SPI.h>
#include <Adafruit_PN532.h>

// --- CONFIGURATION LAN ---
const char* ssid = "OpenGate-D103";
const char* password = "OpenGate2607";

// --- CONFIGURATION IP STATIQUE ---
IPAddress local_IP(192, 168, 103, 10);
IPAddress gateway(192, 168, 103, 1);
IPAddress subnet(255, 255, 255, 0);
IPAddress primaryDNS(0, 0, 0, 0);
IPAddress secondaryDNS(0, 0, 0, 0);

// --- CONFIGURATION MQTT ---
const char* mqtt_server = "192.168.103.1";
const int mqtt_port = 1883;
const char* clientId = "ESP32_D103_Lecteur";
const char* mqtt_user = "mqtt_opengate";
const char* mqtt_password = "OpenGate2607";
const char* topic_recep = "opengate/D103/lecteur/led";
const char* topic_envoi = "opengate/D103/lecteur";

// --- CONFIGURATION HARDWARE ---
const int LED_PIN = 8; // Déplacé sur le Pin 8 (le Pin 7 est réservé au SS du SPI)

// --- CONFIGURATION BUS SPI (ESP32-C3 SuperMini) ---
#define PN532_SCK  4
#define PN532_MISO 5
#define PN532_MOSI 6
#define PN532_SS   7

Adafruit_PN532 nfc(PN532_SCK, PN532_MISO, PN532_MOSI, PN532_SS);

WiFiClient espClient;
PubSubClient client(espClient);

// ----------------- FONCTIONS -----------------
void setup_wifi() {
  Serial.print("[DEBUG] Adresse MAC matérielle : "); Serial.println(WiFi.macAddress());
  
  WiFi.disconnect(true, true);
  delay(1000);
  
  Serial.print("[DEBUG] Tentative d'association de niveau 2 au SSID : "); Serial.println(ssid);

  WiFi.config(local_IP, gateway, subnet, primaryDNS, secondaryDNS);
  WiFi.begin(ssid, password);

  int attempts = 0;
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
    attempts++;
    if (attempts > 20) {
      Serial.println("\n[ERREUR] Délai d'attente dépassé (Timeout Wi-Fi). Vérifie la passerelle Edge (Raspi) !");
      attempts = 0; 
    }
  }
  
  Serial.println("\n[SUCCES] Couche liaison établie. Wi-Fi connecté.");
  Serial.print("[DEBUG] IP locale attribuée : "); Serial.println(WiFi.localIP());
  Serial.print("[DEBUG] Masque sous-réseau : "); Serial.println(WiFi.subnetMask());
  Serial.print("[DEBUG] Passerelle de routage : "); Serial.println(WiFi.gatewayIP());
  Serial.print("[DEBUG] Puissance du signal radio (RSSI) : "); Serial.print(WiFi.RSSI()); Serial.println(" dBm");
}

void reconnect() {
  while (!client.connected()) {
    Serial.println("\n[DEBUG] Établissement de la socket TCP vers le broker MQTT en cours...");
    
    if (client.connect(clientId, mqtt_user, mqtt_password)) {
      Serial.println("[SUCCES] Handshake MQTT validé avec Mosquitto !");
      client.subscribe(topic_recep);
      Serial.print("[DEBUG] Souscription active sur le topic de retour : "); Serial.println(topic_recep);
    } else {
      Serial.print("[ERREUR] Rejet de connexion par le broker. Code d'état = "); Serial.print(client.state());
      Serial.println("\n[DEBUG] Nouvel essai réseau dans 5 secondes...");
      delay(5000);
    }
  }
}

void callback(char* topic, byte* payload, unsigned int length) {
  String message = "";
  for (unsigned int i = 0; i < length; i++) {
    message += (char)payload[i];
  }
  
  Serial.print("\n[MQTT] Trame applicative reçue sur ["); Serial.print(topic); Serial.print("] -> Payload : "); Serial.println(message);

  if (message == "OUVRIR") {
    Serial.println("[ACTION] >> Autorisation validée par le serveur. Allumage de la LED d'état (Accès accordé).");
    digitalWrite(LED_PIN, HIGH);
    
    delay(3000); // Maintien de l'affichage visuel pendant la temporisation de la porte
    
    digitalWrite(LED_PIN, LOW);
    Serial.println("[ACTION] << Fin de temporisation, extinction de la LED.");
  }
}

// ----------------- SETUP -----------------
void setup() {
  Serial.begin(115200);
  Serial.println("\n[SYSTEME] Démarrage de la séquence d'amorçage de la passerelle d'acquisition RFID...");

  pinMode(LED_PIN, OUTPUT);
  digitalWrite(LED_PIN, LOW);

  setup_wifi();
  
  client.setServer(mqtt_server, mqtt_port);
  client.setCallback(callback);

  // Initialisation matérielle du bus SPI
  SPI.begin(PN532_SCK, PN532_MISO, PN532_MOSI, PN532_SS);
  nfc.begin();

  uint32_t versiondata = nfc.getFirmwareVersion();
  if (!versiondata) {
    Serial.println("[ERREUR MATERIELLE] Communication impossible avec la puce PN532.");
    Serial.println("[SOLUTION] Contrôlez le câblage MISO/MOSI et la position du Dip Switch (0 1) sur la platine rouge.");
    while (1); // Halt système
  }

  Serial.println("[SUCCES] Puce RFID PN532 interfacée sur le bus SPI.");
  nfc.SAMConfig(); // Configuration de la puce pour l'acquisition de cartes
  Serial.println("[SYSTEME] Séquence d'amorçage terminée. Prêt pour l'acquisition série.");
}

// ----------------- LOOP -----------------
void loop() {
  if (!client.connected()) {
    reconnect();
  }
  client.loop(); // Maintien indispensable du tunnel TCP et traitement des callbacks

  uint8_t success;
  uint8_t uid[] = { 0, 0, 0, 0, 0, 0, 0 };
  uint8_t uidLength;

  // Lecture RFID non-bloquante avec timeout de 100ms
  // Crucial pour ne pas geler la fonction client.loop() de MQTT
  success = nfc.readPassiveTargetID(PN532_MIFARE_ISO14443A, uid, &uidLength, 100);
  
  if (success) {
    Serial.println("\n[RFID] Interruption matérielle : Badge détecté dans le champ magnétique !");
    Serial.print("[RFID] Extraction de la charge utile. Longueur : "); Serial.print(uidLength, DEC); Serial.println(" octets");
    
    String uidString = "";
    for (uint8_t i = 0; i < uidLength; i++) {
      // Formatage de chaque octet en hexadécimal majuscule
      if (uid[i] < 0x10) uidString += "0"; // Ajout du zéro initial si nécessaire
      uidString += String(uid[i], HEX);
    }
    
    uidString.toUpperCase(); // Uniformisation de la chaîne pour la BDD
    
    Serial.print("[DATA] UID numérisé : "); Serial.println(uidString);
    Serial.print("[MQTT] Injection du payload sur le topic ["); Serial.print(topic_envoi); Serial.println("]...");
    
    // Publication de la chaîne hexadécimale vers le serveur
    client.publish(topic_envoi, uidString.c_str());
    
    Serial.println("[SUCCES] Trame expédiée sur le réseau local.");
    
    // Temporisation de sécurité pour éviter le flood réseau (Replay accidentel du même badge)
    delay(2000); 
  }
}
