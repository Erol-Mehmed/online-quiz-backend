// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function openDeleteModal(actionUrl, id, itemName) {
    const form = document.getElementById("confirmDeleteForm");
    form.action = actionUrl;
    document.getElementById("confirmDeleteId").value = id;
    document.getElementById("confirmDeleteMessage").innerText = `Are you sure you want to delete "${itemName}"?`;

    const modal = new bootstrap.Modal(document.getElementById("confirmDeleteModal"));
    modal.show();
}
