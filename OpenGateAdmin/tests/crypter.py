import bcrypt

passwords = ["axel123", "sacha123", "joris123", "theo123", "4125"]

for pwd in passwords:
    hashed = bcrypt.hashpw(pwd.encode("utf-8"), bcrypt.gensalt())
    print(f"{pwd} → {hashed.decode('utf-8')}")
