from fastapi import APIRouter, Depends, Request
from fastapi.responses import JSONResponse

# from fastapi.responses import JSONResponse
from pydantic import BaseModel
from sqlalchemy import text

from config import default_message
from core.database_manager import engine
from core.dependecies import Check_Token

bat_router = APIRouter(prefix="/bat")


@bat_router.get("/")
async def auth():
    return default_message("bat")


class openDoorForm(BaseModel):
    room: int
    place: str
    batiment: str


class lockForm(BaseModel):
    letter: str
    room: int
    place: str
    locked: bool


@bat_router.get("/getBatRoomList")
def getBatRoomList(token=Depends(Check_Token)):
    BatDic = {}
    with engine.connect() as conn:
        rows = conn.execute(text("SELECT * FROM [PTUT].[dbo].[OGA_Portes]")).fetchall()
    for row in rows:
        _, bat, room, place, locked = row
        if bat not in BatDic:
            BatDic[bat] = {}
        if room not in BatDic[bat]:
            BatDic[bat][room] = {}
        BatDic[bat][room][place] = {"locked": locked}
    return {"status": "OK", "message": BatDic, "error": None}


@bat_router.post("/setLock")
def setLock(form: lockForm, token=Depends(Check_Token)):
    with engine.connect() as conn:
        req = f"UPDATE [PTUT].[dbo].[OGA_Portes] SET is_locked={1 if form.locked else 0} WHERE batiment='{form.letter}' AND numero='{form.room}' and position='{form.place}'"
        conn.execute(text(req))
        conn.commit()
    return {"status": "OK", "message": "jsp", "error": None}


@bat_router.post("/openDoor")
async def openDoor(form: openDoorForm, request: Request, token=Depends(Check_Token)):
    # Le topic suit le même pattern que les ESP32
    # opengate/{batiment}{salle}/gache
    topic = f"opengate/{form.batiment}{form.room}/gache"
    print(topic)
    try:
        request.app.state.mqtt.publish(topic, str("OUVRIR"))
        res = {
            "status": "ok",
            "granted": True,
            "message": f"Accès autorisé pour {form.batiment}{form.room}",
        }
    except Exception as e:
        res = {
            "status": "error",
            "granted": False,
            "message": str(e),
        }
    # request.app.state.mqtt.publish(topic, str(res))
    return JSONResponse(content=res)
