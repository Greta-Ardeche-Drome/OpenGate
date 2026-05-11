import configparser
import os


def getConfAgent():
    config = configparser.ConfigParser()
    base_dir = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
    path = os.path.join(base_dir, "config.ini")
    config.read(path)
    print("Chemin config:", os.path.join(base_dir, "config.ini"))
    print("Sections après lecture:", config.sections())
    return config, path


def getConf(section, cle):
    config, path = getConfAgent()
    return config[section][cle]


def saveConf(section, cle, valeur):
    config, path = getConfAgent()
    config[section][cle] = valeur
    with open(path, "w") as f:
        config.write(f)
