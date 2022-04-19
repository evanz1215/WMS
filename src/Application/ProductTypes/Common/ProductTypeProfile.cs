using Application.ProductTypes.CreateProductType;
using Application.ProductTypes.GetProductType;
using Application.ProductTypes.PatchProductType;
using AutoMapper;
using Domain.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductTypes.Common
{
    public class ProductTypeProfile : Profile
    {
        public ProductTypeProfile()
        {
            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<CreateProductTypeCommand, ProductType>();
            CreateMap<ProductTypeForUpdateDto, ProductType>().ReverseMap();
        }
    }
}
