import React from 'react'

const Register = () => {
  return (
    <div className='register-container'>
        <h1>Register</h1>
        <div className='register-form'>
            <label className='form-labels'>First Name:</label>
            <input type='text' className='forms-input' id='firstName'></input>
            <label className='form-labels'>Last Name:</label>
            <input type='text' className='forms-input' id='lastName'></input>
            <label className='form-labels'>Email:</label>
            <input type='text' className='forms-input' id='Email'></input>
            <label className='form-labels'>Username:</label>
            <input type='text' className='forms-input' id='Username'></input>
            <label className='form-labels'>Password:</label>
            <input type='password' className='forms-input' id='password'></input>
            <label className='form-labels'>telephone:</label>
            <input type='text' className='forms-input' id='telephone'></input>
            <button className='form-submit' onClick={registerUser}>Submit</button>
        </div>
    </div>
  )
}

function registerUser() {
  //api call
  const uri = 'https://localhost:44394/api/Authenticate/Register';
  //variables are each of the text boxes to get the data out of them
  const firstNameTextBox = document.getElementById('firstName');
  const lastNameTextbox = document.getElementById('lastName');
  const emailTextbox = document.getElementById('Email');
  const usernameTextbox = document.getElementById('Username');
  const passwordTextbox = document.getElementById('password');
  const telephoneTextbox = document.getElementById('telephone')
  
  //a variable that will be built by the information from the text boxes
  const user = {
    isComplete: false,
    firstName: firstNameTextBox.value.trim(),
    lastName: lastNameTextbox.value.trim(),
    Email: emailTextbox.value.trim(),
    Username: usernameTextbox.value.trim(),
    password: passwordTextbox.value.trim(),
    telephone: telephoneTextbox.value.trim()
  };

  fetch(uri, {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(user)
  })
  .then(response => response.json())
  .then(() => {
    console.log("sucess")
  })
}
export default Register