using Microsoft.EntityFrameworkCore;
using myMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace eCommerce.DAL
{
    public class ProductRepository
    {
        private CommerceDbContext _db;
        public ProductRepository(CommerceDbContext db)
        {
            _db = db;
        }
        public ProductRepository()
        {
            _db = new CommerceDbContext();
        }

        public void Add(Product product)
        {
            try
            {
                _db.Products.Add(product);
                _db.SaveChanges();
            }
            catch(SqlException ex)
            {
              throw;
            }
           
        }

        public void AddRange(List<Product> products)
        {
            _db.AddRange(products);
            _db.SaveChanges();
        }

        public void Update(Product updatedProduct)
        {
            _db.Products.Attach(updatedProduct);
            _db.Entry<Product>(updatedProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            // updating specific fields
            Product productToUpdated = _db.Products.Where(p => p.Id == updatedProduct.Id).First();
            productToUpdated.Price = updatedProduct.Price;
            productToUpdated.Name = updatedProduct.Name;
            _db.SaveChanges();
        }
        public void Delete(Product product)
        {
            // this is another options _db.Remove<Product>(product);
            _db.Products.Remove(product);
            _db.SaveChanges();
        }

        public Product GetBy(int productId)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == productId);
            return product;
        }

        public List<Product> GetBy(string name)
        {
            return _db.Products.Where(p => p.Name.Contains(name)).ToList();
        }

        public List<Product> Get(string name)
        {
            return _db.Products.FromSql<Product>("select * from products where Name like '%{0}%'", name).ToList();
        }



             

    }
}
