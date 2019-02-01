using System;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
