using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeagensBakeryApi.Models
{
    public class Categories
    {
        public int id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
