using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KeagensBakeryWebAPI.Models
{
    public class AppUsers : IdentityUser<int>
    {
        //[Required]
        //[DataType(DataType.Text)]
        //[Display(Name = "First Name")]
        public string First_Name { get; set; }

        //[Required]
        //[DataType(DataType.Text)]
        //[Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        public DateTime DOB { get; set; }
        public string StreetAddress {get; set;}

        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

    }
}
