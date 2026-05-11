from fastapi import APIRouter, Depends
from pydantic import BaseModel

from config import default_message
from core.config_manager import getConf, saveConf
from core.dependecies import Check_Token

ldap_router = APIRouter(prefix="/ldap")


@ldap_router.get("/")
async def auth():
    return default_message("ldap")


class LdapConfigForm(BaseModel):
    # Rajoute tes vars tq -> nom: type
    domain: str
    server: str
    port: str
    filtre: str


@ldap_router.post("/saveConfig")
async def saveConfig(form: LdapConfigForm, token=Depends(Check_Token)):
    try:
        saveConf("LDAP", "domain", form.domain)
        saveConf("LDAP", "server", form.server)
        saveConf("LDAP", "port", form.port)
        saveConf("LDAP", "filtre", form.filtre)
        return {
            "status": "OK",
            "message": "Configuration sauvegardée.",
            "error": None,
        }
    except Exception as e:
        return {
            "status": "error",
            "message": "Erreur lors de la sauvegarde.",
            "error": str(e),
        }


@ldap_router.get("/getConfig")
async def getConfig(token=Depends(Check_Token)):
    try:
        return {
            "status": "OK",
            "message": {
                "domain": getConf("LDAP", "domain"),
                "server": getConf("LDAP", "server"),
                "port": getConf("LDAP", "port"),
                "filtre": getConf("LDAP", "filtre"),
            },
            "error": None,
        }
    except Exception as e:
        return {
            "status": "error",
            "message": "Erreur lors de la récupération de la configuration",
            "error": str(e),
        }
