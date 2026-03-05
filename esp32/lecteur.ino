#include <WiFi.h>
#include <PubSubClient.h>

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
const char* clientId = "ESP32_D103_Gache";
const char* mqtt_user = "mqtt_opengate";
const char* mqtt_password = "OpenGate2607";
const char* topic_recep = "opengate/raspi/D103/gache";
const char* topic_envoi = "opengate/esp32/D103/gache";

// --- CONFIGURATION HARDWARE ---
const int LED_PIN = 7;
const int BTN_PIN = 1;

WiFiClient espClient;
PubSubClient client(espClient);

// ----------------- FONCTIONS -----------------
void setup_wifi() {
  Serial.print("[DEBUG] Adresse MAC matérielle : "); Serial.println(WiFi.macAddress());
  
  WiFi.disconnect(true, true);
  delay(1000);
  
  Serial.print("[DEBUG] Tentative d'association au SSID : "); Serial.println(ssid);

  WiFi.config(local_IP, gateway, subnet, primaryDNS, secondaryDNS);

  WiFi.begin(ssid, password);

  int attempts = 0;
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
    attempts++;
    if (attempts > 20) {
      Serial.println("\n[ERREUR] Délai d'attente dépassé (Timeout Wi-Fi). Vérifie le Raspi !");
      attempts = 0; 
    }
  }
  
  Serial.println("\n[SUCCES] Wi-Fi connecté.");
  Serial.print("[DEBUG] IP locale : "); Serial.println(WiFi.localIP());
  Serial.print("[DEBUG] Masque sous-réseau : "); Serial.println(WiFi.subnetMask());
  Serial.print("[DEBUG] Passerelle : "); Serial.println(WiFi.gatewayIP());
  Serial.print("[DEBUG] Puissance du signal (RSSI) : "); Serial.print(WiFi.RSSI()); Serial.println(" dBm");
}

void reconnect() {
  while (!client.connected()) {
    Serial.println("\n[DEBUG] Connexion au broker MQTT en cours...");
    
    if (client.connect(clientId, mqtt_user, mqtt_password)) {
      Serial.println("[SUCCES] Connecté au broker Mosquitto !");
      client.subscribe(topic_recep);
      Serial.print("[DEBUG] Abonnement actif sur le topic : "); Serial.println(topic_recep);
    } else {
      Serial.print("[ERREUR] Rejet du broker. Code d'état = "); Serial.print(client.state());
      Serial.println(" (Regarde la doc PubSubClient pour la signification du code)");
      Serial.println("[DEBUG] Nouvel essai dans 5 secondes...");
      delay(5000);
    }
  }
}

void callback(char* topic, byte* payload, unsigned int length) {
  String message = "";
  for (unsigned int i = 0; i < length; i++) {
    message += (char)payload[i];
  }
  
  Serial.print("\n[MQTT] Trame reçue sur ["); Serial.print(topic); Serial.print("] -> Payload : "); Serial.println(message);

  if (message == "OUVRIR") {
    Serial.println("[ACTION] >> Déclenchement de la gâche");
    digitalWrite(LED_PIN, HIGH);
    
    delay(3000);
    
    digitalWrite(LED_PIN, LOW);
    Serial.println("[ACTION] << Fin de temporisation, gâche verrouillée");
  }
}

// ----------------- SETUP -----------------
void setup() {
  Serial.begin(115200);

  pinMode(LED_PIN, OUTPUT);
  digitalWrite(LED_PIN, LOW);

  pinMode(BTN_PIN, INPUT_PULLUP);

  setup_wifi();
  client.setServer(mqtt_server, mqtt_port);
  client.setCallback(callback);
}

// ----------------- LOOP -----------------
void loop() {
  if (!client.connected()) {
    reconnect();
  }
  client.loop();

  if (digitalRead(BTN_PIN) == LOW) {
    Serial.println("[DEBUG] Bouton pressé !");
    client.publish(topic_envoi, "PRESSED");
    delay(1000);
  }
}
