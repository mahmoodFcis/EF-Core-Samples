using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.DAL;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.ViewComponents
{
    public class CategoryViewComponent:ViewComponent
    {
        ICategoryRepository _categoryRepository;
        public CategoryViewComponent(ICategoryRepository rep)
        {
            _categoryRepository = rep;
        }

        public  IViewComponentResult Invoke()
        {
            return View("CategoriesViewComponent",_categoryRepository.GetAll());
        }
    }
}
