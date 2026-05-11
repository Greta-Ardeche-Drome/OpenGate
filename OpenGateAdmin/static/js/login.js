// ============================================
// LOGIN.JS — Cardinal
// ============================================

document.addEventListener('DOMContentLoaded', () => {
    // ── Refs ──────────────────────────────────
    const form          = document.getElementById('loginForm');
    const usernameInput = document.getElementById('username');
    const pwInput       = document.getElementById('password');
    const srvAuthSelect = document.getElementById('authServer');
    const pwToggle      = document.getElementById('pwToggle');
    const submitBtn     = document.getElementById('submitBtn');
    const usernameError = document.getElementById('usernameError');
    const pwError       = document.getElementById('pwError');

    // ── Password visibility toggle ────────────
    const eyeOpen = `<svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 24 24"
        fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
        <path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"/>
        <circle cx="12" cy="12" r="3"/>
    </svg>`;

    const eyeClosed = `<svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 24 24"
        fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
        <path d="M17.94 17.94A10.07 10.07 0 0 1 12 20c-7 0-11-8-11-8a18.45 18.45 0 0 1 5.06-5.94"/>
        <path d="M9.9 4.24A9.12 9.12 0 0 1 12 4c7 0 11 8 11 8a18.5 18.5 0 0 1-2.16 3.19"/>
        <line x1="1" y1="1" x2="23" y2="23"/>
    </svg>`;

    let pwVisible = false;

    pwToggle.addEventListener('click', () => {
        pwVisible = !pwVisible;
        pwInput.type = pwVisible ? 'text' : 'password';
        pwToggle.innerHTML = pwVisible ? eyeClosed : eyeOpen;
        pwToggle.setAttribute('aria-label', pwVisible ? 'Masquer le mot de passe' : 'Afficher le mot de passe');
    });

    // ── Validation helpers ────────────────────
    function setError(input, errorEl, msg) {
        input.classList.add('error');
        errorEl.querySelector('span').textContent = msg;
        errorEl.classList.add('visible');
    }

    function clearError(input, errorEl) {
        input.classList.remove('error');
        errorEl.classList.remove('visible');
    }

    usernameInput.addEventListener('input', () => clearError(usernameInput, usernameError));
    pwInput.addEventListener('input',       () => clearError(pwInput,       pwError));

    // ── Form submit ───────────────────────────
    form.addEventListener('submit', async (e) => {
        e.preventDefault();

        const username = usernameInput.value.trim();
        const password = pwInput.value;
        let valid = true;

        clearError(usernameInput, usernameError);
        clearError(pwInput, pwError);

        if (!username) {
        setError(usernameInput, usernameError, '↳ Champ requis');
        valid = false;
        }

        if (!password) {
        setError(pwInput, pwError, '↳ Champ requis');
        valid = false;
        }

        if (!valid) return;

        // Loading state
        submitBtn.disabled = true;
        submitBtn.classList.add('loading');
        
        const srvAuthValue = srvAuthSelect.value;
        await authenticate(username, password, srvAuthValue);

        submitBtn.disabled = false;
        submitBtn.classList.remove('loading');
    });

    // ── Auth ──────────────────────────────────
    async function authenticate(username, password, authSrv) {
        const response = await fetch("/auth/verify_login", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ username, password, authSrv })
        });

        const data = await response.json();
        console.log(data)
        if (data.result.status == "OK"){
            window.location.href = "/home";
        } else {
            if (data.result.error == "UserNotFound") {
                setError(usernameInput, usernameError, '↳ Utilisateur non trouvé');
            } else if (data.result.error == "WrongPassword") {
                setError(pwInput, pwError, '↳ Mot de passe incorrect');
            }
        }
}}); 