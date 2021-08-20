using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using KeagensBakery.Models;
using KeagensBakery.Helper;
using Newtonsoft.Json;

namespace KeagensBakery.Controllers
{
    public class UserController : Controller
    {
        HelperAPI helperApi = new HelperAPI();
        string BaseURL = "https://localhost:44389/";
        public async Task<IActionResult> GetUsers()
        {

            List<Users> user = new List<Users>();
            HttpClient client = helperApi.client();
            HttpResponseMessage res = await client.GetAsync("api/users");
            if(res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<List< Users >> (results);
            }
            return View(user);
            
        }
    }
}
