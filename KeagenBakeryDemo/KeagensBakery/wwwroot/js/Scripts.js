var slideIndex = 0;
showSlides();
//slide show for homepage
function showSlides() {
    var i;
    var slides = document.getElementsByClassName("BakerySlides");
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slideIndex++;
    if (slideIndex > slides.length) { slideIndex = 1 }
    slides[slideIndex - 1].style.display = "block";
    setTimeout(showSlides, 4000); // Change image every 4 seconds
}

//function for dropdown product list
function OptionSelection() {
    console.log(25);
    //var obj = document.getElementsById("BrownieCookies");
    //var SingleImg = document.getElementById("SingleCookie");
    //var PackageImg = document.getElementById("PackageCookie");
    //SingleImg.style.display = 'none';
    //PackageImg.style.display = 'inline';
    //if (obj.options[obj.selectedIndex].Text == "Single Cookie $1.29") {
    //    PackageImg.style.display = 'none';
    //    SingleImg.style.display = 'inline';
    //}
    //if (obj.options[obj.selectedIndex].Text == "6 Cookies $5.99") {
    //    SingleImg.style.display = 'none';
    //    PackageImg.style.display = 'inline';
    //}
}


