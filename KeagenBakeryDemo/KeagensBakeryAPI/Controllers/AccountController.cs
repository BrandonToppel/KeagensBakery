using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeagensBakeryAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KeagensBakeryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUser Input { get; set; }

        public AccountController(
            UserManager<ApplicationUser> userManger,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManger;
            _signInManager = signInManager;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(Users apps)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = apps.Email, Email = apps.Email };
                IdentityResult result = await _userManager.CreateAsync(user, apps.Password);
                if (result.Succeeded)
                {

                }
                else
                {
                   
                }

            }

            return Ok();
        }
    }
}
