using System;
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

        //Method to Post users 
        public IActionResult CreateCustomer(Customers customer)
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
    }
}
