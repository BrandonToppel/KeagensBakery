var slideIndex = 0;
const uri = 'https://localhost:44361/api/Authenticate';

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

//This is the signup function for registering users
function AddUsers() {
    const addFNameTextBox = document.getElementById('first-name').value;
    const addLNameTextBox = document.getElementById('last-name').value;
    const addEmailTextBox = document.getElementById('email').value;
    const addPasswordTextBox = document.getElementById('userPassword').value;

    let item = {
        //isComplete: false,
        Frist_Name: addFNameTextBox.trim(),
        Last_Name: addLNameTextBox.trim(),
        Email: addEmailTextBox.trim(),
        Password: addPasswordTextBox.trim()
    };

    fetch(uri, {
        method: 'POST',
        mode: 'cors',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'

        },
        body: JSON.stringify(item),
    })
        .then(response => response.json())
        .then(() => {

            addFNameTextBox.value = '';
            addLNameTextBox.value = '';
            addEmailTextBox.value = '';
            addPasswordTextBox.value = '';
            Redirect();

        })
  
        .catch(error => console.error('Unable to add item.', error));
}

function Redirect() {
    //Redirect to homepage after registeration is complete
    window.location.href = 'https://localhost:44335/';
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


