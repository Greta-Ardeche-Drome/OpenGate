import os

from dotenv import load_dotenv

load_dotenv()  # charge le .env


def get_env_var(var):
    return os.getenv(var)

