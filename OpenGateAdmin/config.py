from random import choice

CharaList = [
    "Zero Two",
    "Yelan",
    "Asuna",
    "Tsunade",
    "Makima",
    "Tifa",
    "Erza",
    "Boa Hancock",
    "Hinata",
]

what = {
    "root": "step on me",
    "auth": "spit on me",
    "data": "notice me",
    "page": "love me",
    "sql": "hack me",
}


def default_message(where):
    return {"message": f"I want {choice(CharaList)} to {what[where]}"}


services_to_check = [
    "ssh",
    "apache2",
    "MC-VP-Serv",
]

prefered_workingdir_path = {
    "chicken": "/home/chicken",
    "zanblue": "/home/zanblue",
}

corespondance_ls = {
    "d": "directory",
    "-": "file",
    "l": "link",
    "b": "block device",
    "c": "character device",
    "p": "pipe",
    "s": "socket",
}
