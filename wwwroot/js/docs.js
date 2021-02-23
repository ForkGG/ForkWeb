$(document).ready(function () {
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
                scrollTop: $(hash).offset().top
            }, 0, function () {

                // Add hash (#) to URL when done scrolling (default click behavior)
                window.location.hash = hash;
            });
        } // End if
    });
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
                $(mutation.target.parentElement).addClass('active');
            }
        }
    }
});