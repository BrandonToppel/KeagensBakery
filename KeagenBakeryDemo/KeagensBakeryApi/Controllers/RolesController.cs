using KeagensBakeryApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeagensBakeryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        readonly RoleManager<ApplicationRoles> _rolemanager;
        public RolesController(RoleManager<ApplicationRoles> roleManager)
        {
            _rolemanager = roleManager;
        }
        //api/Roles
        [HttpPost]
        //Method that calls the CreateAsync function to create a user role
        public async Task<IActionResult> Create(ApplicationRoles Name)
        {
            IdentityResult result = await _rolemanager.CreateAsync(Name);
            //Return error if information is not correct 
            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok();
        }
    }
}
