using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int UserId { get; set; }
        public string Total { get; set; }
        public string DateCreated { get; set; }
    }
}
