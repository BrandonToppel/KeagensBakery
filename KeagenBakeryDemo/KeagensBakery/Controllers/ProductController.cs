﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KeagensBakery.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult BrownieChocolateChipCookie()
        {
            return View();
        }
        //Macaron Section
        public IActionResult OreoMacaron()
        {
            return View();
        }
    }
}