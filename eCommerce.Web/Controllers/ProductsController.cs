using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eCommerce.DAL;
using eCommerce.Models;
using eCommerce.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Web.Controllers
{
    [Route("Product/[Action]")]
    public class ProductsController:Controller
    {
        private IProductRepository _productRep;
        private IMapper _mapper;

        public ProductsController(IProductRepository productRep,IMapper mapper)
        {
            this._productRep = productRep;
            _mapper = mapper;
        }
        //[Route("")]
        //[Route("List")]
       // [NonAction]
       [Authorize(Roles ="Customer")]
       //[ResponseCache()]
        public IActionResult Index()
        {
            
            var products = _productRep.GetAll();
            TempData["Copyright"] = "Copyrights reserver @"+DateTime.Now.Year.ToString();
            ViewData["Title"] = "Products List";
            HttpContext.Session.SetString("Name", "Mahmoud");
            List<ProductViewModel> productVMs = new List<ProductViewModel>();
            // manual mapping of models 
            // products.ForEach(p => productVMs.Add(new ProductViewModel() { Name = p.Name, Price = p.Price }));

            _mapper.Map(products, productVMs);
            return View(productVMs);
        }
        public IActionResult Add()
        {
            return View("Add", new ProductAddViewModel());
        }
        [HttpPost]
        public IActionResult Add(ProductAddViewModel productViewModel)
        {
            if(ModelState.IsValid)
            {
                var product = new Product();
                _mapper.Map(productViewModel, product);
                _productRep.Add(product);
                return RedirectToAction("AddConfirmation");
            }
           
           else return View("Add", productViewModel);
        }
        public IActionResult AddConfirmation()
        {
            return View();
        }
    }
}
