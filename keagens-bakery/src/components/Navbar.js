import React from 'react'
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faBars} from "@fortawesome/free-solid-svg-icons";
import {faTimes} from "@fortawesome/free-solid-svg-icons";

const Navbar = () => {
  return (
    <div className='Navbar'>
        <h1 id='logo'>Keagen's Bakery</h1>
        <button onClick={NavControl} className="fa-Bars"><FontAwesomeIcon icon = {faBars}  color="black" size='xl'></FontAwesomeIcon></button>
        <div className='NavMenu'>
        <ul id='NavItem'>
            <li>Home</li>
            <li>Bakery</li>
            <li>About</li>
            <li>Contact</li>
        </ul>
        </div>
    </div>
  )
}

//function that will display the mobile navigation menu
function NavControl() {
  var x = document.getElementById("NavItem");

  if(x.style.display === "none") {
    x.style.display = "block";
  }
  else {
    x.style.display = "none";
  }
}

export default Navbar