# db/database.py
import warnings

from sqlalchemy import create_engine
from sqlalchemy.exc import SAWarning

warnings.filterwarnings("ignore", category=SAWarning)

engine = create_engine(
    "mssql+pyodbc://ptut:ptut@SRV-BDD.opengate.net/PTUT"
    "?driver=ODBC+Driver+18+for+SQL+Server"
    "&TrustServerCertificate=yes"
)
