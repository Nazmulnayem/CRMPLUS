// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function clickinside() {
    openNav();
    functionIsRunning = 1;
};
function openNav() {
    document.getElementById("mySidenav").style.width = "13rem";
    document.getElementById("main").style.marginLeft = "13rem";
    $(".menu-text").show();
    $(".closebtn").show();
    $("#the-basics").attr("placeholder", "Search");
    //$(".stacked-menu-has-collapsible .has-child>.menu-link:after").addClass("addDownArrow");
}
function closeNav() {

    document.getElementById("mySidenav").style.width = "75px";
    document.getElementById("main").style.marginLeft = "75px";
    console.log(document.querySelectorAll(".menu-item.has-child"));
    var menulist = document.querySelectorAll(".menu-item.has-child");
    menulist.forEach(function (item, index) {
        if (item.classList.contains("has-open")) {
            var openclass = document.querySelector(".has-open");
            openclass.classList.remove("has-open");
        }
    })

    $(".menu-text").css("display", "none");
    console.log($(".menu-text"));
    //$(".stacked-menu-has-collapsible .has-child>.menu-link:after").removeClass("removeDownArrow");

    $("#the-basics").attr("placeholder", "");
    //  $("li").removeClass("has-open");
}
