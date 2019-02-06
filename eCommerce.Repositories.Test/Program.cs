using eCommerce.DAL;
using System;
using eCommerce.Models;
using System.Linq;

namespace eCommerce.Repositories.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductRepository productsRepo = new ProductRepository();
            var product = new Product() { Name = "Mobile", Price = 3000, Category = new Category() { Name = "Phones" } };
            productsRepo.Add(product);
            //Console.WriteLine(product.Id);

            //var product = productsRepo.GetByView();

            //int numberOfAffectedRows=productsRepo.AddBySPFromContext("mobile", 100, 1);
        }
    }
}
