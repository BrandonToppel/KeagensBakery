using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeagensBakeryAPI.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        //string instead of int for other countries
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public ApplicationUser()
        {

        }
    }
    
}
