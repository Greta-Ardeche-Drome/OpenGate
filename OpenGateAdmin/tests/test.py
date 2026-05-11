from ldap3 import Server, Connection, ALL, SUBTREE, ALL_ATTRIBUTES
from ldap3.core.exceptions import LDAPException

# ─────────────────────────────────────────
# CONFIG  (équivalent de LdapConfig en C#)
# ─────────────────────────────────────────
LDAP_HOST    = "ldaps://192.168.0.1"
LDAP_PORT    = 636
BIND_DN      = "CN=sacha renard,OU=Admins,OU=Utilisateurs,DC=opengate,DC=net"   # compte de service
BIND_PASSWD  = "OpenGate26"
BASE_DN      = "DC=opengate,DC=net"
USE_SSL      = True


# ─────────────────────────────────────────
# 1. CONNEXION / TEST  (= btnTest_Click)
# ─────────────────────────────────────────
def connect(host, port, bind_dn, passwd, use_ssl=False) -> Connection:
    server = Server(host, port=port, use_ssl=use_ssl, get_info=ALL)
    conn   = Connection(server, user=bind_dn, password=passwd, auto_bind=True)
    # auto_bind=True déclenche le bind immédiatement → lève une exception si KO
    return conn


# ─────────────────────────────────────────
# 2. RECHERCHE D'UTILISATEURS  (= SearchRequest en C#)
# ─────────────────────────────────────────
def search_users(conn: Connection, base_dn: str, filtre: str = "(objectClass=person)"):
    conn.search(
        search_base=base_dn,
        search_filter=filtre,
        search_scope=SUBTREE,           # équivalent SearchScope.Subtree
        attributes=ALL_ATTRIBUTES       # récupère tous les attributs
    )
    return conn.entries     # liste d'objets Entry


# ─────────────────────────────────────────
# 3. AUTH D'UN UTILISATEUR  (= AuthLDAP en C#)
#    On tente un bind avec les creds de l'user
# ─────────────────────────────────────────
def auth_user(host, port, base_dn, username, passwd, use_ssl=False) -> bool:
    server = Server(host, port=port, use_ssl=use_ssl)

    # 1. Bind avec le compte de service pour trouver le DN de l'user
    with Connection(server, user=BIND_DN, password=BIND_PASSWD, auto_bind=True) as conn:
        conn.search(
            search_base=base_dn,
            search_filter=f"(sAMAccountName={username})",   # filtre AD classique
            search_scope=SUBTREE,
            attributes=["distinguishedName"]
        )
        if not conn.entries:
            return False
        user_dn = conn.entries[0].distinguishedName.value

    # 2. Bind avec le DN trouvé + mot de passe de l'user
    with Connection(server, user=user_dn, password=passwd, auto_bind=True) as user_conn:
        return user_conn.bound   # True si le bind a réussi


# ─────────────────────────────────────────
# DEMO
# ─────────────────────────────────────────
if __name__ == "__main__":
    try:
        # Test connexion
        conn = connect(LDAP_HOST, LDAP_PORT, BIND_DN, BIND_PASSWD, USE_SSL)
        print("✅ Connexion OK")

        # Recherche tous les users
        users = search_users(conn, BASE_DN, "(objectClass=person)")
        for u in users:
            print(f"  → {u.cn} | {u.name}")   # attributs accessibles comme des props

        # Auth d'un user spécifique
        ok = auth_user(LDAP_HOST, LDAP_PORT, BASE_DN, "jdupont", "sonMotDePasse")
        print(f"Auth jdupont : {'✅' if ok else '❌'}")

        conn.unbind()

    except LDAPException as e:
        print(f"❌ Erreur LDAP : {e}")