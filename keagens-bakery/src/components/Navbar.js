import React from 'react'
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import {faBars} from "@fortawesome/free-solid-svg-icons";
import {faTimes} from "@fortawesome/free-solid-svg-icons";
import {faUser} from "@fortawesome/free-solid-svg-icons";
import {NavLink} from "react-router-dom";


const Navbar = () => {
  return (
    <div className='Navbar'>
        <h1 id='logo'>Keagen's Bakery</h1>
        <button onClick={NavControl} className="fa-Bars"><FontAwesomeIcon icon = {faBars} className= "fa-bars-icon" color="black" size='2xl'></FontAwesomeIcon></button>
        <button onClick={NavControl} className="fa-Times"><FontAwesomeIcon icon = {faTimes} className = "fa-Times-Icon" color='black' size='2xl'></FontAwesomeIcon></button>
        <div className='NavMenu'>
        <ul id='NavItem'>
            <NavLink to="/"  className={({ isActive }) => (isActive ? 'active' : 'inactive')}><li>Home</li></NavLink>
            <NavLink to="/Bakery" className={({ isActive }) => (isActive ? 'active' : 'inactive')}><li>Bakery</li></NavLink>
            <NavLink to="/About" className={({ isActive }) => (isActive ? 'active' : 'inactive')}><li>About</li></NavLink>
            <li><NavLink to ="/" className={({ isActive }) => (isActive ? 'active' : 'inactive')}>Contact</NavLink></li>
            <li><input type="text" placeholder='search' id='search-Bar'></input></li>
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

export default Navbar