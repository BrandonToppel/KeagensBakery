using KeagensBakeryApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KeagensBakeryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly UserManager<ApplicationUsers> _userManager;
        private readonly SignInManager<ApplicationUsers> _signInManager;
        private readonly RoleManager<ApplicationRoles> _roleManager;
        List<ApplicationUsers> _list = new List<ApplicationUsers>();
        public AuthenticateController(UserManager<ApplicationUsers> userManager, SignInManager<ApplicationUsers> signInManager, RoleManager<ApplicationRoles> roleManager, IConfiguration configuration)
        {
             Configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }
       
        //Small class based on the InputModel that comes with Identity Core
        public class InputModel
        {
            public string password { get; set; }
            public bool rememberMe { get; set; }
        }
        //Get the user claim based on UserRoles, RoleClaims and UserClaims

        //Builds the JWT
        private string GenerateJWT(ApplicationUsers users, List<string> roles)
        {
            var _jwtKey = Configuration["Jwt:Key"];
            var secuirtyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var credentials = new SigningCredentials(secuirtyKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, users.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, users.Email),
                new Claim(ClaimTypes.Email, users.Email)
            };

            //Roles claims from the List of user roles
            foreach (var elements in roles)
            {
                var r = new Claim(ClaimTypes.Role, elements);
                claims.Add(r);
            }
            var token = new JwtSecurityToken(
                issuer: "Jwt:Issuer",
                audience: "Jwt:Issuer",
                claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private void SetJWTCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddMinutes(5)
            };
            Response.Cookies.Append("jwtCookie", token, cookieOptions);
        }
        //[AllowAnonymous]
        //[HttpPost]
        //[Route("Login")]
        //public IActionResult Login(ApplicationUsers users)
        //{
        //    users.Email = "Toppelbman@Gmail.com";
        //    users.firstName = "Brandon";
        //    users.lastName = "Toppel";
        //    var accessToken = GenerateJWT(users);
        //    SetJWTCookie(accessToken);
        //    return Ok(accessToken);
        //}

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        //Login Authentication and creating a JWT if the login is a success 
        public async Task<IActionResult> Login(ApplicationUsers user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.password, user.rememberMe, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                //Finding a user by their email because the email in this application must always be unique
                //it will then allow us to build a list of the users roles to put into the token. 
                var _user = await _userManager.FindByEmailAsync(user.Email);
                List<string> roles = (List<string>)await _userManager.GetRolesAsync(_user);
                var accessToken = GenerateJWT(user, roles);
                SetJWTCookie(accessToken);
                return Ok(accessToken);
            }
        }

        [HttpPost]
        [Route("Register")]
        //Creates users using identity core
        public async Task<IActionResult> Register(ApplicationUsers Input)
        {
            //Create the user using properties from Application Users, and the built in ones from Identity.
            var user = new ApplicationUsers
            {
                UserName = Input.UserName,
                Email = Input.Email,
                firstName = Input.firstName,
                lastName = Input.lastName,
                createdAt = DateTime.Now,

            };
            IdentityResult result = await _userManager.CreateAsync(user, Input.password);
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                return StatusCode(StatusCodes.Status201Created);
            }
        }

        //Edit Users Role
        [HttpPut]
        [Route("RoleEdit")]
        public async Task<IActionResult> RoleEdit(ApplicationUsers Input)
        {
            var user = new ApplicationUsers
            {
                Email = Input.Email
            };
            IdentityResult result = await _userManager.AddToRoleAsync(user, "Admin");
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
