// EmpTrack — site.js
// Handles: sidebar toggle, TempData banner auto-dismiss, export dropdown,
//          photo preview, file list, Aadhaar toggle, tab switching,
//          bulk checkbox selection, form submit spinner

document.addEventListener('DOMContentLoaded', function () {

    // ── Auto-dismiss TempData banner ─────────────────────────────────
    const banner = document.getElementById('tempBanner');
    if (banner) {
        setTimeout(() => {
            banner.style.transition = 'opacity 0.4s ease';
            banner.style.opacity = '0';
            setTimeout(() => banner.remove(), 400);
        }, 5000);
    }

    // ── Export dropdown ──────────────────────────────────────────────
    const exportBtn = document.getElementById('exportBtn');
    const exportDropdown = document.getElementById('exportDropdown');
    if (exportBtn && exportDropdown) {
        exportBtn.addEventListener('click', function (e) {
            e.stopPropagation();
            exportDropdown.classList.toggle('open');
        });
        document.addEventListener('click', function () {
            exportDropdown.classList.remove('open');
        });
    }

    // ── Photo upload preview ─────────────────────────────────────────
    const photoInput = document.getElementById('profilePhotoInput');
    const photoPreview = document.getElementById('photoPreview');
    const photoPreviewWrap = document.getElementById('photoPreviewWrap');
    if (photoInput) {
        photoInput.addEventListener('change', function () {
            const file = this.files[0];
            if (file && photoPreview) {
                const reader = new FileReader();
                reader.onload = e => {
                    photoPreview.src = e.target.result;
                    if (photoPreviewWrap) photoPreviewWrap.classList.add('visible');
                };
                reader.readAsDataURL(file);
            }
        });

        // Drag-drop zone
        const dropZone = document.getElementById('photoDropZone');
        if (dropZone) {
            dropZone.addEventListener('click', () => photoInput.click());
            dropZone.addEventListener('dragover', e => { e.preventDefault(); dropZone.classList.add('dragover'); });
            dropZone.addEventListener('dragleave', () => dropZone.classList.remove('dragover'));
            dropZone.addEventListener('drop', function (e) {
                e.preventDefault();
                dropZone.classList.remove('dragover');
                if (e.dataTransfer.files.length) {
                    photoInput.files = e.dataTransfer.files;
                    photoInput.dispatchEvent(new Event('change'));
                }
            });
        }
    }

    // ── Multi-file document upload list ─────────────────────────────
    const docInput = document.getElementById('documentsInput');
    const docList = document.getElementById('docList');
    if (docInput && docList) {
        docInput.addEventListener('change', function () {
            renderDocList(Array.from(this.files));
        });

        const docDropZone = document.getElementById('docDropZone');
        if (docDropZone) {
            docDropZone.addEventListener('click', () => docInput.click());
            docDropZone.addEventListener('dragover', e => { e.preventDefault(); docDropZone.classList.add('dragover'); });
            docDropZone.addEventListener('dragleave', () => docDropZone.classList.remove('dragover'));
            docDropZone.addEventListener('drop', function (e) {
                e.preventDefault();
                docDropZone.classList.remove('dragover');
                docInput.files = e.dataTransfer.files;
                docInput.dispatchEvent(new Event('change'));
            });
        }
    }

    function renderDocList(files) {
        if (!docList) return;
        docList.innerHTML = '';
        files.forEach((file, i) => {
            const item = document.createElement('div');
            item.className = 'file-item';
            item.innerHTML = `
                <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M14 2H6a2 2 0 0 0-2 2v16a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V8z"/><polyline points="14 2 14 8 20 8"/></svg>
                <span class="file-item-name">${file.name}</span>
                <span class="file-item-remove" onclick="removeFile(${i})">✕ Remove</span>
            `;
            docList.appendChild(item);
        });
    }

    // ── Aadhaar show/hide toggle ─────────────────────────────────────
    const aadhaarToggle = document.getElementById('aadhaarToggle');
    const aadhaarInput = document.getElementById('aadhaarInput');
    if (aadhaarToggle && aadhaarInput) {
        aadhaarToggle.addEventListener('click', function () {
            const isPassword = aadhaarInput.type === 'password';
            aadhaarInput.type = isPassword ? 'text' : 'password';
            aadhaarToggle.innerHTML = isPassword
                ? `<svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M17.94 17.94A10.07 10.07 0 0 1 12 20c-7 0-11-8-11-8a18.45 18.45 0 0 1 5.06-5.94M9.9 4.24A9.12 9.12 0 0 1 12 4c7 0 11 8 11 8a18.5 18.5 0 0 1-2.16 3.19m-6.72-1.07a3 3 0 1 1-4.24-4.24"/><line x1="1" y1="1" x2="23" y2="23"/></svg>`
                : `<svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"/><circle cx="12" cy="12" r="3"/></svg>`;
        });
    }

    // ── Details page Aadhaar reveal ──────────────────────────────────
    const aadhaarReveal = document.getElementById('aadhaarReveal');
    const aadhaarMasked = document.getElementById('aadhaarMasked');
    const aadhaarFull = document.getElementById('aadhaarFull');
    if (aadhaarReveal && aadhaarMasked && aadhaarFull) {
        let revealed = false;
        aadhaarReveal.addEventListener('click', function () {
            revealed = !revealed;
            aadhaarMasked.style.display = revealed ? 'none' : 'inline';
            aadhaarFull.style.display = revealed ? 'inline' : 'none';
            aadhaarReveal.title = revealed ? 'Hide Aadhaar' : 'Reveal Aadhaar';
        });
    }

    // ── Tab switching ────────────────────────────────────────────────
    document.querySelectorAll('.tab-btn').forEach(btn => {
        btn.addEventListener('click', function () {
            const target = this.dataset.tab;
            document.querySelectorAll('.tab-btn').forEach(b => b.classList.remove('active'));
            document.querySelectorAll('.tab-panel').forEach(p => p.classList.remove('active'));
            this.classList.add('active');
            const panel = document.getElementById('tab-' + target);
            if (panel) panel.classList.add('active');
        });
    });

    // ── Bulk checkbox selection ──────────────────────────────────────
    const selectAll = document.getElementById('selectAll');
    const bulkBar = document.getElementById('bulkActionBar');
    const selectedCount = document.getElementById('selectedCount');

    if (selectAll) {
        selectAll.addEventListener('change', function () {
            document.querySelectorAll('.row-checkbox').forEach(cb => {
                cb.checked = this.checked;
                cb.closest('tr')?.classList.toggle('selected', this.checked);
            });
            updateBulkBar();
        });

        document.querySelectorAll('.row-checkbox').forEach(cb => {
            cb.addEventListener('change', function () {
                this.closest('tr')?.classList.toggle('selected', this.checked);
                const all = document.querySelectorAll('.row-checkbox');
                const checked = document.querySelectorAll('.row-checkbox:checked');
                selectAll.checked = all.length === checked.length;
                selectAll.indeterminate = checked.length > 0 && checked.length < all.length;
                updateBulkBar();
            });
        });
    }

    function updateBulkBar() {
        const checked = document.querySelectorAll('.row-checkbox:checked');
        if (bulkBar) bulkBar.classList.toggle('visible', checked.length > 0);
        if (selectedCount) selectedCount.textContent = checked.length;
    }

    // ── Form submit spinner ──────────────────────────────────────────
    document.querySelectorAll('form[data-spinner]').forEach(form => {
        form.addEventListener('submit', function () {
            const btn = this.querySelector('[data-spinner-btn]');
            if (btn) {
                btn.disabled = true;
                btn.innerHTML = `<svg class="spin" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" stroke-linecap="round" stroke-linejoin="round"><path d="M21 12a9 9 0 1 1-6.219-8.56"/></svg> Saving...`;
            }
        });
    });

});

// Spinner animation via dynamic style
const style = document.createElement('style');
style.textContent = `@keyframes spin { to { transform: rotate(360deg); } } .spin { animation: spin 0.7s linear infinite; }`;
document.head.appendChild(style);

// ── Sidebar toggle ──────────────────────────────────────────────────
function toggleSidebar() {
    const sidebar = document.getElementById('sidebar');
    const overlay = document.getElementById('sidebarOverlay');
    sidebar?.classList.toggle('open');
    overlay?.classList.toggle('open');
}

function closeSidebar() {
    document.getElementById('sidebar')?.classList.remove('open');
    document.getElementById('sidebarOverlay')?.classList.remove('open');
}
