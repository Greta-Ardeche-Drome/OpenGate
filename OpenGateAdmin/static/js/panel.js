// ============================================
// PANEL.JS — Cardinal
// Sidebar accordion + toggle + horloge
// ============================================

document.addEventListener('DOMContentLoaded', () => {

    // ── Refs ──────────────────────────────────
    const layout        = document.querySelector('.panel-layout');
    const sidebarToggle = document.getElementById('sidebarToggle');
    const navGroups     = document.querySelectorAll('.nav-group');
    const clock         = document.getElementById('topbarClock');

    // ── Sidebar accordion ─────────────────────
    navGroups.forEach(group => {
        const trigger = group.querySelector('.nav-group-trigger');

        trigger.addEventListener('click', () => {
            const isOpen = group.classList.contains('open');

            // navGroups.forEach(g => g.classList.remove('open'));

            if (!isOpen) {
                group.classList.add('open');
            }
        });
    });

    // ── Sidebar collapse (desktop) / overlay (mobile) ──
    const isMobile = () => window.innerWidth <= 768;

    sidebarToggle.addEventListener('click', () => {
        if (isMobile()) {
            layout.classList.toggle('sidebar-open');
        } else {
            layout.classList.toggle('sidebar-collapsed');
            // Persiste la préférence
            const collapsed = layout.classList.contains('sidebar-collapsed');
            localStorage.setItem('sidebar-collapsed', collapsed ? '1' : '0');
        }
    });

    // Ferme le drawer mobile en cliquant l'overlay
    layout.addEventListener('click', (e) => {
        if (isMobile() && layout.classList.contains('sidebar-open')) {
            // Clique en dehors de la sidebar
            if (!e.target.closest('.sidebar')) {
                layout.classList.remove('sidebar-open');
            }
        }
    });

    // Restaure l'état collapse au chargement (desktop)
    if (!isMobile() && localStorage.getItem('sidebar-collapsed') === '1') {
        layout.classList.add('sidebar-collapsed');
    }

    // ── Horloge topbar ────────────────────────
    function updateClock() {
        const now = new Date();
        const h = String(now.getHours()).padStart(2, '0');
        const m = String(now.getMinutes()).padStart(2, '0');
        const s = String(now.getSeconds()).padStart(2, '0');
        clock.textContent = `${h}:${m}:${s}`;
    }

    updateClock();
    setInterval(updateClock, 1000);

});