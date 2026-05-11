const API_BASE = window.location.origin

function print(str){
    console.log(str);
}

async function fetchWithAuth(url, options = {}) {
    const token = localStorage.getItem("token")
    if (token) {
        options.headers = {
            ...options.headers,
            "Authorization": `Bearer ${token}`
        };
    }
    const response = await fetch(url, options);
    return response;
}

document.addEventListener("DOMContentLoaded", () => {
    const themeToggle = document.getElementById("themeToggle");
    const themeLabel = themeToggle.querySelector(".btn-text");

    function updateThemeLabel(theme) {
        themeLabel.textContent = theme === 'light' ? 'Mode sombre' : 'Mode clair';
    }

    updateThemeLabel(document.documentElement.getAttribute('data-theme'));

    themeToggle.addEventListener("click", () => {
        const current = document.documentElement.getAttribute('data-theme');
        const mod = current === 'light' ? 'dark' : 'light';
        document.documentElement.setAttribute('data-theme', mod);
        localStorage.setItem('theme', mod);
        updateThemeLabel(mod);
    });

    const logoutBtn = document.querySelector(".logout-btn");
    if (logoutBtn) {
        logoutBtn.addEventListener("click", (e) => {
            e.preventDefault();
            localStorage.removeItem("token");
            localStorage.removeItem("username");
            window.location.href = "/login";
        });
    }
});

function createElement(tag, attrs = {}, children = []) {
    const el = document.createElement(tag);
    for (const [key, value] of Object.entries(attrs)) {
        el.setAttribute(key, value);
    }
    children.forEach(child => el.appendChild(child));
    return el;
}

function getTokenPayload() {
    const token = localStorage.getItem('token') // ou là où tu le stockes
    const payload = token.split('.')[1]
    return JSON.parse(atob(payload))
}