using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eCommerce.Models;
using eCommerce.Web.ViewModels;

namespace eCommerce.Web.MappingProfiles
{
    public class DomainToViewModelProfile:Profile
    {
        public DomainToViewModelProfile()
        {
           CreateMap<Product, ProductViewModel>()
                .BeforeMap((p, pVm)=>{
               pVm.ProductName = p.Name+"Product";
            })
                .ReverseMap();

            CreateMap<ProductAddViewModel, Product>().ReverseMap();
            CreateMap<CategoryViewModel, Category>().ReverseMap();

        }
    }
}
