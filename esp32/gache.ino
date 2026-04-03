#include <WiFi.h>
#include <PubSubClient.h>
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
IPAddress local_IP(192, 168, 103, 20);
IPAddress gateway(192, 168, 103, 1);
IPAddress subnet(255, 255, 255, 0);
IPAddress primaryDNS(0, 0, 0, 0);
IPAddress secondaryDNS(0, 0, 0, 0);

// --- CONFIGURATION MQTT ---
const char* mqtt_server = "192.168.103.1";
const int mqtt_port = 8883;
const char* clientId = "ESP32_D103_Gache";
const char* mqtt_user = "mqtt_opengate";
const char* mqtt_password = "OpenGate2607";
const char* topic_recep = "opengate/D103/gache";

// --- CONFIGURATION HARDWARE ---
const int RELAY_PIN = 7;
const int BUTTON_PIN = 9;

WiFiClientSecure espClient;
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
}

void reconnect() {
  while (!client.connected()) {
    Serial.println("\n[DEBUG] Connexion au broker MQTT en cours...");
    espClient.setCACert(ca_cert);
    if (client.connect(clientId, mqtt_user, mqtt_password)) {
      Serial.println("[SUCCES] Connecté au broker Mosquitto !");
      client.subscribe(topic_recep);
      Serial.print("[DEBUG] Abonnement actif sur le topic : "); Serial.println(topic_recep);
    } else {
      Serial.print("[ERREUR] Rejet du broker. Code d'état = "); Serial.print(client.state());
      Serial.println("[DEBUG] Nouvel essai dans 5 secondes...");
      delay(5000);
    }
  }
}

void ouvrir_porte() {
  Serial.println("[ACTION] Coupure du courant (LOW) -> Ouverture de la gâche");
  digitalWrite(RELAY_PIN, LOW);
  delay(3000);
  digitalWrite(RELAY_PIN, HIGH);
  Serial.println("[ACTION] Rétablissement du courant (HIGH) -> Verrouillage de la gâche");
}

void callback(char* topic, byte* payload, unsigned int length) {
  String message = "";
  for (unsigned int i = 0; i < length; i++) {
    message += (char)payload[i];
  }
  
  Serial.print("\n[MQTT] Trame reçue sur ["); Serial.print(topic); Serial.print("] -> Payload : "); Serial.println(message);

  if (message == "OUVRIR") {
    Serial.println("[ACTION] >> Autorisation MQTT validée.");
    ouvrir_porte();
  } 
  else {
    Serial.println("[ALERTE] Payload inconnu ignoré.");
  }
}

// ----------------- SETUP -----------------
void setup() {
  Serial.begin(115200);

  pinMode(RELAY_PIN, OUTPUT);
  digitalWrite(RELAY_PIN, HIGH);
  
  pinMode(BUTTON_PIN, INPUT_PULLUP);

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

  if (digitalRead(BUTTON_PIN) == LOW) {
    Serial.println("\n[ACTION MATERIELLE] Bouton intérieur pressé !");
    ouvrir_porte();
  }
}
