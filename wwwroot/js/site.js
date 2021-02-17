// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$('#screenshotCarousel').on('slide.bs.carousel', function(a){
    switchDescription(a.from, a.to);
});

function switchDescription(from, to){
    let descriptions = $('#screenshotDescriptions').children();
    descriptions[from].className = "d-none";
    descriptions[to].className = "";
}

