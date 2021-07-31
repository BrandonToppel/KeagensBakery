using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class OrderDetailsContext : DbContext
    {
        public OrderDetailsContext(DbContextOptions<OrderDetailsContext> options)
           : base(options)
        {

        }
        public DbSet<OrderDetails> orderDetails { get; set; }
    }
}
