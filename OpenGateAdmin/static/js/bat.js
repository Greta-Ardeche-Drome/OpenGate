async function initPage() {
    const res = await fetchWithAuth(`${API_BASE}/bat/getBatRoomList`);
    const data = (await res.json()).message;
    const batListDiv = document.getElementById("bat-list-div");

    for (const [bat, batContent] of Object.entries(data)) {
        const { batDiv, statTotal, statOpen } = createBatDiv(bat);
        let i = 0;
        for (const [room, roomContent] of Object.entries(batContent)) {
            i++;
            const roomDiv = createRoom(room, roomContent, bat);
            batDiv.appendChild(roomDiv);
            statTotal.innerText = i.toString() + " salles ";
            statOpen.innerText = "0 ouvertes";
        }
        batListDiv.appendChild(batDiv);
    }
}

function createBatDiv(letter) {
    const batDiv = document.createElement("div");
    batDiv.id = "bat-" + letter;
    batDiv.classList.add("bat-div");

    const batHeadDiv = document.createElement("div");
    batHeadDiv.classList.add("bat-head");

    const batNameSpan = document.createElement("span");
    batNameSpan.innerHTML = "Bâtiment " + letter;

    const statsDiv = document.createElement("div");
    statsDiv.classList.add("bat-stat-div");

    const statTotal = document.createElement("span");
    statTotal.id = letter + "-total";
    statsDiv.appendChild(statTotal);

    const statOpen = document.createElement("span");
    statOpen.id = letter + "-open";
    statsDiv.appendChild(statOpen);

    batHeadDiv.appendChild(batNameSpan);
    batHeadDiv.appendChild(statsDiv);
    batDiv.appendChild(batHeadDiv);

    return { batDiv, statTotal, statOpen };
}

function createRoom(number, doors, letter) {
    const roomDiv = document.createElement("div");
    roomDiv.classList.add("salle-card");
    roomDiv.id = "salle-" + number;

    const header = document.createElement("div");
    header.classList.add("salle-header");

    const roomTitle = document.createElement("span");
    roomTitle.classList.add("salle-title");
    roomTitle.innerText = `SALLE ${letter}${number}`;
    header.appendChild(roomTitle);

    // Bouton toggle verrouiller/déverrouiller
    const lockAllBtn = document.createElement("button");
    lockAllBtn.classList.add("btn", "btn-lock");
    lockAllBtn.innerText = "Verrouiller tout";
    lockAllBtn.addEventListener('click', () => toggleLockAll(letter, number, doors, lockAllBtn));
    header.appendChild(lockAllBtn);

    // Bouton ouverture physique
    const openAllBtn = document.createElement("button");
    openAllBtn.classList.add("btn", "btn-unlock");
    openAllBtn.innerText = "Ouvrir tout";
    openAllBtn.addEventListener('click', () => openAll(number, doors, letter));
    header.appendChild(openAllBtn);

    roomDiv.appendChild(header);

    const portesDiv = document.createElement("div");
    portesDiv.classList.add("portes");

    for (const [place, placeContent] of Object.entries(doors)) {
        const label = place === "AV" ? "Porte avant" : place === "AR" ? "Porte arrière" : "Porte unique";
        const isLocked = placeContent.locked;

        const porteRow = document.createElement("div");
        porteRow.classList.add("porte-row");
        porteRow.id = "door-" + number + "-" + place;

        const porteOccupied = document.createElement("span");
        porteOccupied.classList.add("porte-occupied");
        porteOccupied.id = "occupied-" + number + "-" + place;
        porteOccupied.innerText = "Fermé";
        porteRow.appendChild(porteOccupied);

        const porteName = document.createElement("span");
        porteName.classList.add("porte-name");
        porteName.innerText = label;
        porteRow.appendChild(porteName);

        const porteStatus = document.createElement("span");
        porteStatus.classList.add("porte-status", isLocked ? "status-locked" : "status-unlocked");
        porteStatus.innerText = isLocked ? "Verrouillée" : "Déverrouillée";
        porteRow.appendChild(porteStatus);

        // Bouton toggle individuel
        const lockBtn = document.createElement("button");
        lockBtn.classList.add("btn", isLocked ? "btn-unlock" : "btn-lock");
        lockBtn.innerText = isLocked ? "Déverrouiller" : "Verrouiller";
        lockBtn.addEventListener('click', () => toggleLock(letter, number, place, lockBtn, porteStatus));
        porteRow.appendChild(lockBtn);

        // Bouton ouvrir individuel
        const openBtn = document.createElement("button");
        openBtn.classList.add("btn", "btn-unlock");
        openBtn.innerText = "Ouvrir";
        openBtn.addEventListener('click', () => openDoor(number, place, letter));
        porteRow.appendChild(openBtn);

        portesDiv.appendChild(porteRow);
    }

    roomDiv.appendChild(portesDiv);
    return roomDiv;
}

async function toggleLock(letter, number, place, btn, statusSpan) {
    const isLocked = btn.innerText === "Verrouiller";
    const res = await fetchWithAuth(`${API_BASE}/bat/setLock`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ letter, room: number, place, locked: isLocked })
    });
    if (!res.ok) return;

    if (isLocked) {
        btn.innerText = "Déverrouiller";
        btn.classList.replace("btn-lock", "btn-unlock");
        statusSpan.className = "porte-status status-locked";
        statusSpan.innerText = "Verrouillée";
    } else {
        btn.innerText = "Verrouiller";
        btn.classList.replace("btn-unlock", "btn-lock");
        statusSpan.className = "porte-status status-unlocked";
        statusSpan.innerText = "Déverrouillée";
    }
}

async function toggleLockAll(letter, number, doors, btn) {
    const isLocking = btn.innerText === "Verrouiller tout";
    for (const place of Object.keys(doors)) {
        const porteRow = document.getElementById(`door-${number}-${place}`);
        const lockBtn = porteRow.querySelectorAll("button")[0];
        const statusSpan = porteRow.querySelector(".porte-status");
        await toggleLock(letter, number, place, lockBtn, statusSpan);
    }
    btn.innerText = isLocking ? "Déverrouiller tout" : "Verrouiller tout";
}

async function openDoor(number, place, letter) {
    print("ok")
    const data = await fetchWithAuth(`${API_BASE}/bat/openDoor`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ room: number, place, batiment: letter })
    });
    if (data.status == "ok"){
        showToast("Ouverture", "info", `Porte ${number}-${place} ouverte`);
    } else {
        showToast("Erreur.", "error", `Erreur lors de l'ouverture de la porte ${number}-${place}`);
    }
}

async function openAll(number, doors, letter) {
    for (const place of Object.keys(doors)) {
        await openDoor(number, place, letter);
    }
}