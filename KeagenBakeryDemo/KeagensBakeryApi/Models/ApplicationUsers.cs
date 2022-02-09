using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KeagensBakeryApi.Models
{
    public class ApplicationUsers : IdentityUser<int>
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string telephone { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime modifiedAt { get; set; }
        public DateTime birthDate { get; set; }
        public DateTime lastLoggedIn { get; set; }
        [NotMapped]
        public string password { get; set; }
        [NotMapped]
        public bool rememberMe { get; set; }
    }
}
