using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeagensBakeryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeagensBakeryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> RegisterUser()
        {

        }
    }
}
