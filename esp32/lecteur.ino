#include <WiFi.h>
#include <PubSubClient.h>
#include <SPI.h>
#include <Adafruit_PN532.h>
#include <Keypad.h>
#include <WiFiClientSecure.h>

// --- CONFIGURATION LAN ---
const char* ssid = "OpenGate-D103";
const char* password = "OpenGate2607";

const char* ca_cert = \
"-----BEGIN CERTIFICATE-----\n" \
"MIIDazCCAlOgAwIBAgIUAJL2+gA5Cqa7OpnK9CwH9FUEUF8wDQYJKoZIhvcNAQEL\n" \
"BQAwRTELMAkGA1UEBhMCRlIxEzARBgNVBAgMClNvbWUtU3RhdGUxITAfBgNVBAoM\n" \
"GEludGVybmV0IFdpZGdpdHMgUHR5IEx0ZDAeFw0yNjAzMTUxMjE0MDhaFw0yNzAz\n" \
"MTUxMjE0MDhaMEUxCzAJBgNVBAYTAkZSMRMwEQYDVQQIDApTb21lLVN0YXRlMSEw\n" \
"HwYDVQQKDBhJbnRlcm5ldCBXaWRnaXRzIFB0eSBMdGQwggEiMA0GCSqGSIb3DQEB\n" \
"AQUAA4IBDwAwggEKAoIBAQDWVyAyl95puLKaVTc4j1r9ZVR/X30F3D2MZVSQmbJP\n" \
"AgGbMSHjF+IPo6JuudL3fR5qhW/Ztid2/RZcyWrBTRGaj652vZHLdVusgOYUsFFe\n" \
"v8nDij97HMZ8qWPJA9ucM97kb9dTk175t2Smw+hZiCIDOl/9+9nYHQR3cF2qUHp5\n" \
"bZPnRbqtoRRFwgdA6lLgR3yx450cTUSaPDiunxGhgBifzwtJum1KK7UhSMpvoQRX\n" \
"UxesllEFvuIjb8OHw/YrNvCmyvII/7Gg2PpipXfZCDbSm8bNbO+YkiMOfz3jCGz0\n" \
"JsiDhoKqdu0oQJ4UltCRY4AO6cVqHmTjDN9csUW7nZmvAgMBAAGjUzBRMB0GA1Ud\n" \
"DgQWBBRdKIsO5XzWB24/o8Y+K8vdezO9hjAfBgNVHSMEGDAWgBRdKIsO5XzWB24/\n" \
"o8Y+K8vdezO9hjAPBgNVHRMBAf8EBTADAQH/MA0GCSqGSIb3DQEBCwUAA4IBAQCt\n" \
"D6e2hFwAP4H3P37vHuQSneVxiLHCeQB/mjHVTW/x8fmbSSb9AEtWcxOESAFpc5WR\n" \
"YIzSNcsV8gF82/00LPXxQ5ElTxu0yW8szLQD05toOQRRr/ZcZOjtc7tuTnawbnsV\n" \
"V+CE8fEMWu9HrHlvYsTLTObXYCDWLQfi62D8AqPzw95Xu/JrfUtGx81R/E7V4H3q\n" \
"vY6XiYIMc9Q+p1lOE0ouxyRzFW8rMsvtZRkrWWkjonf2u59cPZ+8//hTOsYJKbXe\n" \
"3rsHE6NKI3Pt1aUlxxXJFq8nOS7rIS1gcDkcetQ0hpsZtHxcmEFw1cy/cvheIjPx\n" \
"xlGGktL+imRP14M9PZ+g\n" \
"-----END CERTIFICATE-----\n";

// --- CONFIGURATION IP STATIQUE ---
IPAddress local_IP(192, 168, 103, 10);
IPAddress gateway(192, 168, 103, 1);
IPAddress subnet(255, 255, 255, 0);
IPAddress primaryDNS(0, 0, 0, 0);
IPAddress secondaryDNS(0, 0, 0, 0);

// --- CONFIGURATION MQTT & LOGIQUE ---
const char* mqtt_server = "192.168.103.1";
const int mqtt_port = 8883;
const char* clientId = "ESP32_D103_Lecteur";
const char* mqtt_user = "mqtt_opengate";
const char* mqtt_password = "OpenGate2607";
const char* topic_recep = "opengate/D103/lecteur/led";
const char* topic_envoi = "opengate/D103/lecteur";
const String id_salle = "D103"; 

// --- CONFIGURATION HARDWARE ---
const int LED_PIN = 2; 

// --- CONFIGURATION BUS SPI (PN532) ---
#define PN532_SCK  4
#define PN532_MISO 3
#define PN532_MOSI 1
#define PN532_SS   0

Adafruit_PN532 nfc(PN532_SCK, PN532_MISO, PN532_MOSI, PN532_SS);

// --- CONFIGURATION CLAVIER MATRICIEL ---
const byte ROWS = 4; 
const byte COLS = 4; 

char keys[ROWS][COLS] = {
  {'E','0','.','V'},
  {'1','2','3','v'},
  {'7','8','9','<'},
  {'4','5','6','^'}
};

byte rowPins[ROWS] = {5, 6, 7, 8}; 
byte colPins[COLS] = {9, 10, 20, 21}; 

Keypad keypad = Keypad(makeKeymap(keys), rowPins, colPins, ROWS, COLS);

// --- VARIABLES DE DOUBLE AUTHENTIFICATION ---
String currentUID = "";
String currentPIN = "";
bool waitingForPIN = false;
unsigned long timeBadgeScanned = 0;

WiFiClientSecure espClient;
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
}

void reconnect() {
  while (!client.connected()) {
    Serial.println("\n[DEBUG] Établissement de la socket TCP vers le broker MQTT en cours...");
    espClient.setCACert(ca_cert);
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
    delay(3000); 
    digitalWrite(LED_PIN, LOW);
    Serial.println("[ACTION] << Fin de temporisation, extinction de la LED.");
  }
}

void resetAuthentication() {
  waitingForPIN = false;
  currentUID = "";
  currentPIN = "";
  Serial.println("[SYSTEME] Session d'authentification réinitialisée.");
}

// ----------------- SETUP -----------------
void setup() {
  Serial.begin(115200);
  Serial.println("\n[SYSTEME] Démarrage de la séquence d'amorçage de la passerelle d'acquisition RFID + PIN...");

  pinMode(LED_PIN, OUTPUT);
  digitalWrite(LED_PIN, LOW);

  setup_wifi();
  
  client.setServer(mqtt_server, mqtt_port);
  client.setCallback(callback);

  SPI.begin(PN532_SCK, PN532_MISO, PN532_MOSI, PN532_SS);
  nfc.begin();

  uint32_t versiondata = nfc.getFirmwareVersion();
  if (!versiondata) {
    Serial.println("[ERREUR MATERIELLE] Communication impossible avec la puce PN532.");
    while (1);
  }

  Serial.println("[SUCCES] Puce RFID PN532 interfacée sur le bus SPI.");
  nfc.SAMConfig(); 
  Serial.println("[SYSTEME] Séquence d'amorçage terminée. Prêt pour l'acquisition MFA.");
}

// ----------------- LOOP -----------------
void loop() {
  if (!client.connected()) {
    reconnect();
  }
  client.loop(); 

  // --- GESTION DU CLAVIER ---
  char key = keypad.getKey();
  
  if (key && waitingForPIN) {
    if (key == 'V') { // Flèche d'entrée (en bas à droite) : VALIDER
      if (currentPIN.length() == 4) {
        Serial.println("\n[AUTH] Validation du code PIN. Construction de la trame...");
        
        // Format d'envoi strict : UID|SALLE|MDP
        String payload = currentUID + "|" + currentPIN + "|" + id_salle;
        
        Serial.print("[MQTT] Injection du payload : "); Serial.println(payload);
        client.publish(topic_envoi, payload.c_str());
        Serial.println("[SUCCES] Trame d'authentification complète expédiée.");
        
        resetAuthentication();
      } else {
        Serial.println("\n[ERREUR] Le code PIN doit obligatoirement faire 4 caractères.");
        currentPIN = ""; // On vide pour forcer à recommencer
      }
      
    } else if (key == 'E') { // Touche ESC : ANNULER
      Serial.println("\n[AUTH] Saisie annulée par l'utilisateur (ESC).");
      resetAuthentication();
      
    } else if (key == '<') { // Flèche gauche : EFFACER UN CHIFFRE
      if (currentPIN.length() > 0) {
        currentPIN.remove(currentPIN.length() - 1);
        Serial.print("\b \b"); // Efface l'étoile sur la console
      }
      
    } else if (key != '^' && key != 'v' && key != '.') { 
      // On ignore les flèches haut/bas et le point, on ne garde que les chiffres
      if (currentPIN.length() < 4) {
        currentPIN += key;
        Serial.print("*"); // Masquage de la saisie
      }
    }
  }

  // --- GESTION DU LECTEUR RFID ---
  if (!waitingForPIN) {
    uint8_t success;
    uint8_t uid[] = { 0, 0, 0, 0, 0, 0, 0 };
    uint8_t uidLength;

    success = nfc.readPassiveTargetID(PN532_MIFARE_ISO14443A, uid, &uidLength, 100);
    
    if (success) {
      Serial.println("\n[RFID] Badge détecté. Extraction de l'UID...");
      
      String uidString = "";
      for (uint8_t i = 0; i < uidLength; i++) {
        if (uid[i] < 0x10) uidString += "0";
        uidString += String(uid[i], HEX);
      }
      uidString.toUpperCase();
      
      Serial.print("[DATA] UID numérisé : "); Serial.println(uidString);
      
      currentUID = uidString;
      waitingForPIN = true;
      timeBadgeScanned = millis();
      
      Serial.println("[SYSTEME] Attente de la saisie du code PIN (4 chiffres) puis validation avec 'A'...");
      delay(500); 
    }
  } else {
    if (millis() - timeBadgeScanned > 10000) {
      Serial.println("\n[SYSTEME] Timeout de la session d'authentification (10s écoulées).");
      resetAuthentication();
    }
  }
}
