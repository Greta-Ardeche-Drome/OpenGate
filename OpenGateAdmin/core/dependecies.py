from fastapi import HTTPException, Request

from core.security import verify_token


def Check_Token(request: Request):
    token = request.cookies.get("token")
    if not token:
        raise HTTPException(status_code=307, headers={"Location": "/login"})

    token_verification = verify_token(token)
    if not token_verification["State"]:
        raise HTTPException(status_code=307, headers={"Location": "/login"})

    return token_verification
