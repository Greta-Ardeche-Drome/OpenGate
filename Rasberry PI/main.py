import time, os, logging, ssl
from paho.mqtt import client as mqtt
from paho.mqtt.enums import CallbackAPIVersion

# --- CONFIGURATION ---
BROKER_LOCAL = "raspi-D103.opengate.local"
MAIN_SRV = "srv-bdd.opengate.net"
USER = "mqtt_opengate"
PASSWORD = "OpenGate2607"

LOG_FILE = "/var/log/opengate.log"

CERT = "/etc/mosquitto/ca_certificates/ca.crt"
CERTBDD = "/etc/mosquitto/ca_certificates/caBDD.crt"

connected_local = False
connected_srv = False

# --- TOPICS ---
TOPIC_LECTEUR = "opengate/D103/lecteur"
TOPIC_REQUEST = "opengate/request"
TOPIC_RESPONSE = "opengate/response"
TOPIC_GACHE = "opengate/D103/gache"

# --- FICHIER DE LOG ---

logging.basicConfig(
    level=logging.INFO,
    format='%(asctime)s [%(levelname)s] %(message)s',
    datefmt='%d/%m/%Y %H:%M:%S',
    handlers=[
        logging.FileHandler(LOG_FILE),
        #logging.StreamHandler()   # pour voir aussi à l’écran si besoin
    ]
)

log = logging.getLogger("opengate")

# --- LIENS POUR LE BROKER LOCAL (Lecteur/Gâche) ---

def on_connect_local(client, userdata, flags, rc, properties=None):
    global connected_local

    if rc == 0:
        if not connected_local:
            log.info("Connecté au Broker LOCAL.")
            connected_local = True

        client.subscribe(TOPIC_LECTEUR)
    else:
        log.error(f"Connexion Serveur Local : {rc}")

def on_message_local(client, userdata, msg):
    """Reçoit du lecteur ESP32 -> Envoie vers le serveur Windows"""

    payload = msg.payload.decode()
    log.info(f"[LECTEUR -> RASPI] ID reçu : {payload}")

    try :
        client_srv.publish(TOPIC_REQUEST, payload)
        log.info("[RASPI -> SERVEUR] Transfert de la requête...")
    except Exception as e:
        log.error(f"Impossible de publier sur le serveur : {e}")

# --- LIENS POUR LE SERVEUR WINDOWS (Requête/Réponse) ---

def on_connect_srv(client, userdata, flags, rc, properties=None):
    global connected_srv

    if rc == 0:
        if not connected_srv:
            log.info("Connecté au Serveur WINDOWS.")
            connected_srv = True

        client.subscribe(TOPIC_RESPONSE)
    else:
        log.error(f"Connexion Serveur Windows : {rc}")

def on_message_srv(client, userdata, msg):
    """Reçoit la réponse Windows -> Envoie vers la gâche ESP32"""

    payload = msg.payload.decode()
    log.info(f"[SERVEUR -> RASPI] Réponse reçue : {payload}")

    # Analyse de la réponse (true/false) pour l'ESP
    verdict = "OUVRIR" if any(x in payload.lower() for x in ["true", "a accès"]) else "NON"

    try:
        client_local.publish(TOPIC_GACHE, verdict)
        log.info(f"[RASPI -> GACHE] Envoi du verdict : {verdict}")
    except Exception as e:
        log.error(f"Impossible de publier sur la gâche : {e}")

# --- INITIALISATION DES DEUX CLIENTS ---

# Client 1 : Gère la communication avec les ESP (Local)
client_local = mqtt.Client(CallbackAPIVersion.VERSION2, client_id="RASPI_LOCAL_NODE")
client_local.username_pw_set(USER, PASSWORD)
client_local.tls_set(ca_certs=CERT)
client_local.on_connect = on_connect_local
client_local.on_message = on_message_local

# Client 2 : Gère le pont avec le PC Windows (Distant)
client_srv = mqtt.Client(CallbackAPIVersion.VERSION2, client_id="RASPI_TO_WINDOWS_BRIDGE")
client_srv.username_pw_set(USER, PASSWORD)
client_srv.tls_set(ca_certs=CERTBDD)
client_srv.on_connect = on_connect_srv
client_srv.on_message = on_message_srv

try:
    log.info("Démarrage des connexions MQTT...")

    # Connexions aux deux brokers
    client_local.connect(BROKER_LOCAL, 8883, 60)
    client_srv.connect(MAIN_SRV, 8883, 60)

    # Lancement des threads en arrière-plan (Non-bloquant)
    client_local.loop_start()
    client_srv.loop_start()

    # Boucle principale pour maintenir le script en vie
    while True:
        if not client_local.is_connected():
            try:
                client_local.reconnect()
            except Exception as e:
                log.error(f"Reconnexion au broker local échouée : {e}")

        if not client_srv.is_connected():
            try:
                client_srv.reconnect()
            except Exception as e:
                log.error(f"Reconnexion au serveur Windows échouée : {e}")

        time.sleep(1)

except KeyboardInterrupt:
    log.info("Arrêt du script par l'utilisateur.")
    client_local.loop_stop()
    client_srv.loop_stop()
    client_local.disconnect()
    client_srv.disconnect()
except Exception as e:
    log.error(f"{e}")
