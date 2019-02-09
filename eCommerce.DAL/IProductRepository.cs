using System.Collections.Generic;
using eCommerce.Models;

namespace eCommerce.DAL
{
    public interface IProductRepository
    {
        void Add(Product product);
        
        void AddRange(List<Product> products);
       

        void Update(Product updatedProduct);
       
        void Delete(Product product);
        

        Product GetBy(int productId);
        List<Product> GetAll();

        List<Product> GetBy(string name);
        

         List<Product> GetByLinq(string name);
        

        List<Product> GetByStatement(string name);
        

        List<Product> GetBySP(string name);
        

        List<ProductView> GetByView();

        int AddBySPFromContext(string name, decimal price, int categoryId);
        


    }

}