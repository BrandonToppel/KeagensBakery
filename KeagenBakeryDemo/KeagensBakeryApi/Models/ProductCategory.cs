using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KeagensBakeryApi.Models
{
    public class ProductCategory
    {
        public int ProductsId { get; set; }
        public Products Product { get; set; }
        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }
    }
}
