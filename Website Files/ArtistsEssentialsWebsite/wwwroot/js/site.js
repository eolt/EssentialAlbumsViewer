// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function sortByCritics(id) {
    window.location.href = "/Artist/Details/"+String(id);
}

function sortByCommercial(id) {
    window.location.href = "/Artist/Details/" + String(id) +"?sortby=commercial";
}

function sortByAwards(id) {
    window.location.href = "/Artist/Details/" + String(id) +"?sortby=awards";
}

function sortByOnline(id) {
    window.location.href = "/Artist/Details/" + String(id) + "?sortby=online";
}



