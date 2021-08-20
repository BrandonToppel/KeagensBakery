using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeagensBakery.Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        //public DateTime Bdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
