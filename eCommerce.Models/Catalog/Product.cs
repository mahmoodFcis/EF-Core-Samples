using System;
using System.Collections.Generic;

namespace eCommerce.Models.Catalog
{
    public class Product
    {
        public int Id { get; set; }

        public string ModelNumber { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public Category Category { get; set; }

        public Brand Brand { get; set; }

        public byte[] Image { get; set; }
        public MadeIn MadeIn { get; set; }

        public string Description { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }
        public DateTime DateOfExpiration { get; set; }

    }

    public class MadeIn
    {

        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public List<Product> Products { get; set; }


    }


}
