from fastapi import APIRouter
from fastapi.responses import JSONResponse
from pydantic import BaseModel

from config import default_message
from core.security import create_token, verify_password


class LoginForm(BaseModel):
    username: str
    password: str
    authSrv: str


auth_router = APIRouter(prefix="/auth")


@auth_router.get("/")
async def auth():
    return default_message("auth")


@auth_router.post("/verify_login")
async def verify_login(form: LoginForm):
    result = verify_password(form.username, form.password, form.authSrv)
    if result is not None and result["status"] == "OK":
        token = create_token(form.username)
        response = JSONResponse(content={"result": result})
        response.set_cookie(key="token", value=token, httponly=True)
        return response

    return JSONResponse(content={"result": result})
