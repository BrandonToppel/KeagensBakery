using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeagensBakeryApi.Models
{
    public class Products
    {
        public int id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string descrption { get; set; }
        public string slug { get; set; }
        public string image { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

    }
}
