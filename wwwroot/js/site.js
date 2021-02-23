// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function () {
    setScreenshotDescriptionHeight();

    $('.title').each((index, title) =>{
        mut.observe(title, options);
    });
    $('.entry').each((index, entry) =>{
        mut.observe(entry, options);
    });

    // Add smooth scrolling to all links
    $("a").on('click', function (event) {

        // Make sure this.hash has a value before overriding default behavior
        if (this.hash !== "") {
            // Prevent default anchor click behavior
            event.preventDefault();

            // Store hash
            let hash = this.hash;

            // Using jQuery's animate() method to add smooth page scroll
            // The optional number (800) specifies the number of milliseconds it takes to scroll to the specified area
            $('html, body').animate({
                scrollTop: $(hash).offset().top -60
            }, 0, function () {

                // Add hash (#) to URL when done scrolling (default click behavior)
                //window.location.hash = hash;
            });
        } // End if
    });
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


let options = {attributes: true, childList: true, subtree: true};
let mut = new MutationObserver(function(mutations, mut){
    for(let mutation of mutations){
        if (mutation.type === "attributes" && mutation.attributeName === "class"){
            if(mutation.target.getAttribute("class").includes("active")){
                $('.chapter').each(function(){
                   if($(this).hasClass('active'))
                       $(this).removeClass('active');
                });
                
                mutation.target.parentElement.setAttribute("class", "chapter active");
            }
        }
    }
});


