import React from 'react'

const Navbar = () => {
  return (
    <div className='Navbar'>
        <h1 id='logo'>Keagen's Bakery</h1>
        <ul className='NavMenu'>
            <li id='NavItem'>Home</li>
            <li id='NavItem'>Bakery</li>
            <li id='NavItem'>About</li>
            <li id='NavItem'>Contact</li>
        </ul>
    </div>
  )
}

export default Navbar