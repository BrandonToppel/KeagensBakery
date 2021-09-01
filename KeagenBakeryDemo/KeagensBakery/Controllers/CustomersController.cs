﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using KeagensBakery.Helper;
using KeagensBakery.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KeagensBakery.Controllers
{
    public class CustomersController : Controller
    {
        HelperAPI helperApi = new HelperAPI();
        string BaseURL = "https://localhost:44389/";

        //Method to Login in, so it will retrieve users
        //public async Task<IActionResult> CustomerLogin()
        //{
        //    List<Customers> customers = new List<Customers>();
        //}
        public async Task<IActionResult> GetCustomers()
        {

            List<Customers> customers = new List<Customers>();
            HttpClient client = helperApi.client();
            HttpResponseMessage res = await client.GetAsync("api/Customers");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<Customers>>(results);
            }
            return View(customers);

        }
        public IActionResult CreateCustomers()
        {
            return View();
        }
        //Method to Post users 
        [HttpPost]
        public IActionResult CreateCustomers(Customers customer)
        {
            HttpClient client = helperApi.client();
            var postTask = client.PostAsJsonAsync<Customers>("api/Customers", customer);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}