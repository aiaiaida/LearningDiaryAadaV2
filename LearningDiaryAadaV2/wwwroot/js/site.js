﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function showManual() {
    var el = document.getElementById('manual');
    if (el.classList.contains('hide')) {
        el.classList.remove('hide');
    }
    else {
        el.classList.add('hide')
    }
    
}