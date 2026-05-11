async function initPage() {
    getConfig();
    const saveBtn = document.getElementById("saveBtn");
    saveBtn.addEventListener('click', () => {
        SaveConfig();
    });
}

async function getConfig(){
    const res = await fetchWithAuth(`${API_BASE}/ldap/getConfig`)
    const data = await res.json();

    if (data.status != "OK"){
        showToast("Erreur", "error", `${data.message} ${data.error}`)
    } else {
        document.getElementById("domain").value = data.message.domain;
        document.getElementById("server").value = data.message.port;
        document.getElementById("port").value = data.message.server;
        document.getElementById("filtre").value = data.message.filtre;
    }   
}

async function SaveConfig() {
    // Récupère les valeurs des inputs tq 
    // const nomAuPifVALUE = document.getelementById("IdDeL'Input").value;
    const domainValue = document.getElementById("domain").value;
    const portValue = document.getElementById("server").value;
    const serverValue = document.getElementById("port").value;
    const filtreValue = document.getElementById("filtre").value;

    const res = await fetchWithAuth(`${API_BASE}/ldap/saveConfig`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ domain: domainValue, server: serverValue, port: portValue, filtre: filtreValue })
    });

    // Exemple de ce que tu récupère, mais dans ton cas toi tu vas test si ça renvoie (par exemple) data.status == "OK" et le data.message
    const data = await res.json();
    if (data.status == "OK"){
        showToast("Succes", "success", "Configuration enregistrée.")
    } else {
        showToast("Erreur", "error", `Erreur lors de l'enregistrement de la conf\n${data.error}`)
    }

    // pour le showToast c'est showToast(Titre, type, message)
    // Type peut être : 
    // success: 'Succès',
    // error:   'Erreur',
    // warning: 'Attention',
    // info:    'Info',
}   