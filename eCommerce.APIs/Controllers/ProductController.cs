using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eCommerce.DAL;
using eCommerce.Models;
using eCommerce.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRep;
        private IMapper _mapper;

        public ProductController(IProductRepository productRep,IMapper mapper)
        {
            this._productRep = productRep;
            this._mapper = mapper;
        }
        [HttpGet("List")]
        public List<ProductViewModel> Get()
        {
            var products = _productRep.GetAll();
            return _mapper.Map<List<ProductViewModel>>(products);
        }
        [HttpGet("FindById/{id}")]
        public ProductViewModel Get(int id)
        {
            var product = _productRep.GetBy(id);
            return _mapper.Map<ProductViewModel>(product);
        }

        [HttpPost]
        public IActionResult Post(ProductAddViewModel productVM)
        {
            //if(ModelState.IsValid)

            var product = _mapper.Map<Product>(productVM);
            _productRep.Add(product);
            return Ok(product);

        }

        [HttpPut]
        public IActionResult Put(ProductUpdateViewModel productToUpdate)
        {
            var product = _mapper.Map<Product>(productToUpdate);
            _productRep.Update(product);
            return Ok(product);


        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            var product = _productRep.GetBy(id);
            if (product == null)
            {
                return NotFound($"Product with Id {id} does not exist");

            }
            else
            {
                _productRep.Delete(product);
                return Ok(product);
            }
        }

    }
}