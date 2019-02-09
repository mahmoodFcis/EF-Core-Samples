using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eCommerce.Models;

namespace eCommerce.DAL
{
    public class CategoryRepository:ICategoryRepository
    {
        CommerceDbContext _db;
        public CategoryRepository()
        {
            _db = new CommerceDbContext();
        }

        public List<Category> GetAll()
        {
            return _db.Categories.ToList();
        }
    }

    public interface ICategoryRepository
    {
        List<Category> GetAll();
    }
}
