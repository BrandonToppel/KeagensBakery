import React from 'react'
import { NavLink } from 'react-router-dom'

const Login = () => {
  return (
    <div className='login-container'>
        <h1 id='Login-Title'>Login</h1>
        <div className='login-form'>
            <label className='labels'>Email</label>
            <input type="text" id='email-textbox'></input>
            <label className='labels'>Password</label>
            <input type="password" id='password-textbox'></input>
            <button id='login-button'>Login</button>
            <NavLink to='/Register'><p id='Register-link'>Don't have an account? Create one! Click here.</p></NavLink>
        </div>

    </div>
  )
}

export default Login