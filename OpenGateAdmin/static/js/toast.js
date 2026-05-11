// ============================================
// TOAST.JS — Système de notifications Cardinal
// ============================================
// Utilisation :
//   showToast('Connexion réussie')
//   showToast('Erreur SQL', 'error', 'Colonne inconnue : username2')
//   showToast('Sauvegardé', 'success')
//   showToast('Attention', 'warning', 'Action irréversible')
// ============================================

const TOAST_MAX    = 3;       // max toasts affichés simultanément
const TOAST_DURATION = 4000;  // durée en ms avant disparition auto

const TOAST_ICONS = {
  success: `<svg class="toast-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"
              fill="none" stroke="currentColor" stroke-width="2.5"
              stroke-linecap="round" stroke-linejoin="round">
              <polyline points="20 6 9 17 4 12"/>
            </svg>`,
  error:   `<svg class="toast-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"
              fill="none" stroke="currentColor" stroke-width="2.5"
              stroke-linecap="round" stroke-linejoin="round">
              <circle cx="12" cy="12" r="10"/>
              <line x1="12" y1="8" x2="12" y2="12"/>
              <line x1="12" y1="16" x2="12.01" y2="16"/>
            </svg>`,
  warning: `<svg class="toast-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"
              fill="none" stroke="currentColor" stroke-width="2.5"
              stroke-linecap="round" stroke-linejoin="round">
              <path d="M10.29 3.86L1.82 18a2 2 0 0 0 1.71 3h16.94a2 2 0 0 0 1.71-3L13.71 3.86a2 2 0 0 0-3.42 0z"/>
              <line x1="12" y1="9" x2="12" y2="13"/>
              <line x1="12" y1="17" x2="12.01" y2="17"/>
            </svg>`,
  info:    `<svg class="toast-icon" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24"
              fill="none" stroke="currentColor" stroke-width="2.5"
              stroke-linecap="round" stroke-linejoin="round">
              <circle cx="12" cy="12" r="10"/>
              <line x1="12" y1="16" x2="12" y2="12"/>
              <line x1="12" y1="8" x2="12.01" y2="8"/>
            </svg>`,
};

// Titres par défaut selon le type
const TOAST_TITLES = {
  success: 'Succès',
  error:   'Erreur',
  warning: 'Attention',
  info:    'Info',
};

/**
 * Affiche un toast
 * @param {string} title   - Titre principal (ou message court si pas de détail)
 * @param {string} type    - 'success' | 'error' | 'warning' | 'info'
 * @param {string} message - Détail optionnel sous le titre
 */
function showToast(title, type = 'info', message = '') {
  const container = document.getElementById('toast-container');

  // Limite à TOAST_MAX : supprime le plus vieux si dépassé
  const existing = container.querySelectorAll('.toast:not(.removing)');
  if (existing.length >= TOAST_MAX) {
    removeToast(existing[0]);
  }

  // Création du toast
  const toast = document.createElement('div');
  toast.className = `toast ${type}`;
  toast.innerHTML = `
    ${TOAST_ICONS[type] ?? TOAST_ICONS.info}
    <div class="toast-body">
      <span class="toast-title">${title}</span>
      ${message ? `<span class="toast-msg">${message}</span>` : ''}
    </div>
    <button class="toast-close" aria-label="Fermer">✕</button>
    <div class="toast-progress" style="animation-duration: ${TOAST_DURATION}ms"></div>
  `;

  // Fermeture manuelle
  toast.querySelector('.toast-close').addEventListener('click', () => removeToast(toast));

  container.appendChild(toast);

  // Suppression automatique
  const timer = setTimeout(() => removeToast(toast), TOAST_DURATION);

  // Pause au hover
  toast.addEventListener('mouseenter', () => {
    clearTimeout(timer);
    toast.querySelector('.toast-progress').style.animationPlayState = 'paused';
  });

  toast.addEventListener('mouseleave', () => {
    toast.querySelector('.toast-progress').style.animationPlayState = 'running';
    setTimeout(() => removeToast(toast), TOAST_DURATION);
  });
}

/**
 * Retire un toast avec animation de sortie
 * @param {HTMLElement} toast
 */
function removeToast(toast) {
  if (toast.classList.contains('removing')) return; // évite double appel
  toast.classList.add('removing');
  toast.addEventListener('animationend', () => toast.remove(), { once: true });
}