using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        //public DateTime Bdate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //    public int CreditInfo { get; set; }
        //    public DateTime Transactions { get; set; }
        //    public object Id { get; internal set; }
    }
}
