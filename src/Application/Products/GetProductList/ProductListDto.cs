using Application.Common.Mapping;
using AutoMapper;
using Domain.Products;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Products.GetProductList
{
    public class ProductListDto : IMapFrom<Product>
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public string Description { get; set; }
        public int BaseUnitId { get; set; }
        public string BaseUnitName { get; set; }
        public decimal BidPrice { get; set; }
        public decimal AsKPrice { get; set; }



        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductListDto>()
                .ForMember(
                    dest => dest.ProductTypeName,
                    opt => opt.MapFrom(src => src.ProductType.Name)
                )
                .ForMember(
                    dest => dest.BaseUnitName,
                    opt => opt.MapFrom(src => src.Unit.Name)
                )
                ;
        }
    }


}
