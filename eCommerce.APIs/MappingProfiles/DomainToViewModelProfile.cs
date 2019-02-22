using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eCommerce.Models;
using eCommerce.ViewModels;

namespace eCommerce.APIs.MappingProfiles
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
            CreateMap<ProductUpdateViewModel, Product>().ReverseMap();

        }
    }
}
