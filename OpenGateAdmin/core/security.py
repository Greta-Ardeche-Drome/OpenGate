import ssl
from datetime import datetime, timedelta

import bcrypt
from jose import jwt
from jose.exceptions import JWTError
from ldap3 import Connection, Server, Tls
from ldap3.core.exceptions import LDAPException, LDAPInvalidCredentialsResult
from passlib.context import CryptContext
from sqlalchemy import text

from core.config_manager import getConf
from core.database_manager import engine
from core.dotenv_manager import get_env_var

expiration_delta = 3600

algorithm = "HS256"

pwd_context = CryptContext(schemes=["bcrypt"])


def verifyHash(plain: str, hashed: str):
    return bcrypt.checkpw(plain.encode("utf-8"), hashed.encode("utf-8"))


def test_LDAP(user: str, plain: str) -> dict:

    server = getConf("LDAP", "server")
    port = int(getConf("LDAP", "port"))
    domain = getConf("LDAP", "domain")

    tls = Tls(validate=ssl.CERT_NONE)  # équivalent OPT_X_TLS_NEVER
    server = Server(server, port=port, use_ssl=True, tls=tls)
    # base_dn = "dc=opengate,dc=net"
    user_dn = "{}@{}".format(user, domain)

    try:
        conn = Connection(server, user=user_dn, password=plain, auto_bind=True)
        conn.unbind()
        return {
            "status": "OK",
            "message": "Accès autorisé",
            "error": "",
        }
    except LDAPInvalidCredentialsResult:
        return {
            "status": "error",
            "message": "Credentials invalides.",
            "error": "UserNotFound",
        }
    except LDAPException as error:
        print("Error:", error)
        return {
            "status": "error",
            "message": "Erreur lors de l'execution de la requête",
            "error": "UnknownError",
        }


def test_Username(user: str, plain: str) -> dict:
    with engine.connect() as conn:
        rows = conn.execute(
            text(
                f"SELECT TOP 1 username, passwd FROM [PTUT].[dbo].[OGA_Users] where username='{user}'"
            )
        ).fetchone()

        if not rows:
            return {
                "status": "error",
                "message": "Utilisateur introuvable",
                "error": "UserNotFound",
            }
        else:
            if verifyHash(plain, rows[1]):
                return {
                    "status": "OK",
                    "message": "Accès authorisé",
                    "error": "",
                }
            else:
                return {
                    "status": "error",
                    "message": "Mot de passe erroné.",
                    "error": "WrongPassword",
                }


def verify_password(user: str, plain: str, srv: str):
    match srv:
        case "bdd":
            return test_Username(user, plain)
        case "ldap":
            return test_LDAP(user, plain)
        case "other":
            return {
                "status": "error",
                "message": "Erreur serveur lors de l'authentification",
                "error": "SrvError",
            }


def create_token(user_id: str) -> str:
    api_token = get_env_var("API_TOKEN_KEY")
    if api_token is None:
        raise ValueError("API_TOKEN_KEY not found in environment variables")

    expiration_date = datetime.now() + timedelta(seconds=expiration_delta)

    payload = {"sub": user_id, "exp": expiration_date}

    return jwt.encode(payload, api_token, algorithm=algorithm)


def verify_token(token: str) -> dict:
    api_token = get_env_var("API_TOKEN_KEY")
    if api_token is None:
        raise ValueError("API_TOKEN_KEY not found in environment variables")

    try:
        payload = jwt.decode(token, api_token, algorithms=[algorithm])
        return {
            "State": True,
            "message": "Token is valid",
            "user_id": payload.get("sub"),
            "error": None,
        }
    except JWTError as e:
        return {
            "State": False,
            "message": "Invalid token",
            "user_id": None,
            "error": str(e),
        }
