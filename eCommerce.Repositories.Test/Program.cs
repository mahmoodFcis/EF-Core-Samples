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
            //var product = new Product() { Name = "Computer", Price = 3000, Category = new Category() { Name = "Electronics" } };
            //productsRepo.Add(product);
            //Console.WriteLine(product.Id);

            var product = productsRepo.GetByView();

            //int numberOfAffectedRows=productsRepo.AddBySPFromContext("mobile", 100, 1);
        }
    }
}
