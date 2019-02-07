using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers
{
    public class ProductsController : Controller
    {
        
        public ProductsController()
        {
           
        }
        [Authorize()]
        public IActionResult Index()
        {
            TempData["Name"] = "Ahmed";
            return View();
        }
        [ResponseCache(Duration =40)]
        public IActionResult About()
        {

            string name = TempData["Name"].ToString();
            return View();
        }
    }
}