import React from 'react'
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faBars} from "@fortawesome/free-solid-svg-icons";
import {faTimes} from "@fortawesome/free-solid-svg-icons";
import {faUser} from "@fortawesome/free-solid-svg-icons";
import {faMagnifyingGlass} from "@fortawesome/free-solid-svg-icons";
import {NavLink} from "react-router-dom";


const Navbar = () => {
  return (
    <div className='Navbar'>
        <h1 id='logo'>Keagen's Bakery</h1>
        <button onClick={NavControl} className="fa-Bars"><FontAwesomeIcon icon = {faBars} className= "fa-bars-icon" color="black" size='2xl'></FontAwesomeIcon></button>
        <button onClick={NavControl} className="fa-Times"><FontAwesomeIcon icon = {faTimes} className = "fa-Times-Icon" color='black' size='2xl'></FontAwesomeIcon></button>
        <div className='NavMenu'>
        <ul id='NavItem'>
            <NavLink to="/"  className={({ isActive }) => (isActive ? 'active' : 'inactive')} onClick={NavClose}><li>Home</li></NavLink>
            <NavLink to="/Bakery" className={({ isActive }) => (isActive ? 'active' : 'inactive')} onClick={NavClose}><li>Bakery</li></NavLink>
            <NavLink to="/About" className={({ isActive }) => (isActive ? 'active' : 'inactive')} onClick={NavClose}><li>About</li></NavLink>
            <li><NavLink to ="/" className={({ isActive }) => (isActive ? 'active' : 'inactive')}>Contact</NavLink></li>
            <NavLink to="/Login" className={({ isActive }) => (isActive ? 'active' : 'inactive')}><li>Account</li></NavLink>
            <li><input type="text" placeholder='search' id='search-Bar'></input></li>
            <li><button className='fa-Magnifying-Glass'><FontAwesomeIcon icon = {faMagnifyingGlass} className="fa-Magnifying-Glass-Icon"
            color='Black' size='xl'></FontAwesomeIcon></button></li>

        </ul>
        </div>
    </div>
  )
}

//function that will display the mobile navigation menu
function NavControl() {
  var x = document.getElementById("NavItem");
  //Represents a list of items from the fa-Bars class
  var barsIcon = document.getElementsByClassName("fa-Bars");
  var timesIcon = document.getElementsByClassName("fa-Times");

  if(x.style.display === "none") {
    x.style.display = "block";
    //loop to hide the menu bars icon
    for(var i = 0; i < barsIcon.length; i++) {
      barsIcon[i].style.visibility = 'hidden';
    }
    //loop to display the times icon
    for(var i = 0; i < timesIcon.length; i++) {
      timesIcon[i].style.visibility = 'visible';
    }
  }
  else {
    x.style.display = "none";
    //loop to hide times icon
    for(var i = 0; i < timesIcon.length; i++) {
      timesIcon[i].style.visibility = 'hidden';
    }
    //loop to display the menu bar icon
    for(var i = 0; i < barsIcon.length; i++) {
      barsIcon[i].style.visibility = 'visible';
    }
  }
}

//function to close the mobile navigation menu when a link is clicked.
//This function exists because if we were to use NavControl it would also close
//The desktop navigation menu when clicking a link. 
function NavClose() {
  //Gets the width of the screen
  var screenWidth = window.innerWidth;
  var x = document.getElementById("NavItem");
  var barsIcon = document.getElementsByClassName("fa-Bars");
  var timesIcon = document.getElementsByClassName("fa-Times");

  if(screenWidth <= 500) {
    x.style.display = "none";

    for(var i = 0; i < timesIcon.length; i++) {
      timesIcon[i].style.visibility = 'hidden';
    }
    //loop to display the menu bar icon
    for(var i = 0; i < barsIcon.length; i++) {
      barsIcon[i].style.visibility = 'visible';
    }
  }
}

export default Navbar