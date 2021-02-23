// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function () {
    setScreenshotDescriptionHeight();
});

$(window).on('resize', function(){
    setScreenshotDescriptionHeight();
})

$('#screenshotCarousel').on('slide.bs.carousel', function(a){
    switchDescription(a.from, a.to);
});

$(function(){
    $(window).scroll(function(){
        if(!$('#nav-toggle').hasClass("collapsed")){
            $('.collapse').collapse('hide');
        }
    });
});

function switchDescription(from, to){
    let descriptions = $('#screenshotDescriptions').children();
    descriptions[from].className = "d-none";
    descriptions[to].className = "";
}

function openInNewTab(link){
    window.open(link, "_blank");
}

function setScreenshotDescriptionHeight(){
    let maxHeight = 0;
    let descDiv = $('#screenshotDescriptions');
    descDiv.children().each(function(){
        if (this.clientHeight > maxHeight)
            maxHeight = this.clientHeight;
    });
    descDiv.height(maxHeight);
}



function LoadImages(){
    $('img[lazysrc]').each( function(){
            //* set the img src from data-src
            $( this ).attr( 'src', $( this ).attr( 'lazysrc' ) );
        }
    );
}

document.addEventListener('readystatechange', event => {
    if (event.target.readyState === "interactive") {  //or at "complete" if you want it to execute in the most last state of window.
        LoadImages();
    }
});





