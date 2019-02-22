using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace eCommerce.ViewModels
{
    public class ProductAddViewModel
    {
        [Required(ErrorMessage ="Name is required")]
        [Display(Name="Product Name")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [Display(Name="Category")]
        public int CategoryId { get; set; }
        public CategoryViewModel Category { get; set; }
    }

}
