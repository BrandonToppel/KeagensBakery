using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeagensBakeryWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace KeagensBakeryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<AppUsers> _userManager;
        private readonly SignInManager<AppUsers> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<AppUsers> userManager, SignInManager<AppUsers> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }


        //Model to login with without changing the appUser class
        public class InputModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public bool RememberMe { get; set; }
        }
        //Register a user using Identity Core
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(AppUsers appUsers)
        {
            if(ModelState.IsValid)
            {
                var user = new AppUsers
                {
                    UserName = appUsers.Email,
                    Email = appUsers.Email,
                    First_Name = appUsers.First_Name,
                    Last_Name = appUsers.Last_Name,
                };
                IdentityResult result = await _userManager.CreateAsync(user, appUsers.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                else
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
            }
            return Ok();
        }

        //Login user this is also where we will JWT
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(InputModel appUsers)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(appUsers.Email, appUsers.Password, appUsers.RememberMe, lockoutOnFailure: false);
                if(!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                else
                {
                    return StatusCode(StatusCodes.Status202Accepted);
                }
            }
            return Ok();
        }
    }
}
