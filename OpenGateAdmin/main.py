import paho.mqtt.client as mqtt
import uvicorn
from fastapi import Depends, FastAPI, Request
from fastapi.responses import RedirectResponse
from fastapi.staticfiles import StaticFiles
from fastapi.templating import Jinja2Templates
from paho.mqtt.enums import CallbackAPIVersion

from api.auth import auth_router
from api.batiment import bat_router
from api.ldap import ldap_router
from config import default_message
from core.dependecies import Check_Token

mqtt_client = mqtt.Client(CallbackAPIVersion.VERSION2, client_id="ADMIN_PANEL")
mqtt_client.username_pw_set("mqtt_opengate", "OpenGate2607")
mqtt_client.tls_set(ca_certs="C:/OpenGateAdmin/ca_certificates/caBDD.crt")
mqtt_client.connect("raspi-D103.opengate.local", 8883, keepalive=60)
mqtt_client.loop_start()

app = FastAPI()
app.state.mqtt = mqtt_client
app.include_router(auth_router)
app.include_router(ldap_router)
app.include_router(bat_router)
app.mount("/static", StaticFiles(directory="static"), name="static")

templates = Jinja2Templates(directory="templates")


@app.get("/api")
async def api(token=Depends(Check_Token)):
    return default_message("root")


@app.get("/")
async def root():
    return RedirectResponse(url="/home")


@app.get("/home")
async def home(request: Request, token=Depends(Check_Token)):
    return templates.TemplateResponse(
        request, "home.html", {"active": "home", "current_user": token["user_id"]}
    )


@app.get("/batiments")
async def batiments(request: Request, token=Depends(Check_Token)):
    return templates.TemplateResponse(
        request,
        "batiments.html",
        {"active": "batiments", "current_user": token["user_id"]},
    )


@app.get("/acl")
async def acl(request: Request, token=Depends(Check_Token)):
    return templates.TemplateResponse(
        request, "acl.html", {"active": "acl", "current_user": token["user_id"]}
    )


@app.get("/ldap")
async def ldap(request: Request, token=Depends(Check_Token)):
    return templates.TemplateResponse(
        request, "ldap.html", {"active": "ldap", "current_user": token["user_id"]}
    )


@app.get("/logs")
async def logs(request: Request, token=Depends(Check_Token)):
    return templates.TemplateResponse(
        request, "logs.html", {"active": "logs", "current_user": token["user_id"]}
    )


@app.get("/login")
async def login(request: Request):
    return templates.TemplateResponse(request, "login.html")


@app.get("/logout")
async def logout():
    response = RedirectResponse(url="/login")
    response.delete_cookie("token")
    return response


if __name__ == "__main__":
    uvicorn.run("main:app", host="0.0.0.0", port=8000, reload=True)
