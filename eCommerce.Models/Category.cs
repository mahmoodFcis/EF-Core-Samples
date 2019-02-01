using System.Collections.Generic;

namespace eCommerce.Models
{
   public class Category
    {
        public List<Product> Products { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}