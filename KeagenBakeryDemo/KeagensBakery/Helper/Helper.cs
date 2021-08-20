using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KeagensBakery.Helper
{
    public class HelperAPI
    {
        public HttpClient client()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44389/");
            return client;
        }
    }
}
