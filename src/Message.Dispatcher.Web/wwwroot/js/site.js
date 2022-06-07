// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    var navbar = $('#navbar');
    var navbarButton = $('#navbar-button');

    navbarButton.on('click', function (e) {
        e.preventDefault();
        toggleClass(navbar, navbar.hasClass('navbar-expand'), '', 'navbar-expand');
    });

    function toggleClass(el, condition, ifTrue, ifFalse) {
        var addClass = condition ? ifTrue : ifFalse;
        var removeClass = condition ? ifFalse : ifTrue;
        el.addClass(addClass).removeClass(removeClass);
    }
});