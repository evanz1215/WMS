using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.PurchaseOrders.CreatePurchaseOrder;
using AutoMapper;
using Domain.PurchaseOrders;

namespace Application.PurchaseOrders.Common
{
    public class PurchaseOrderProfile : Profile
    {
        public PurchaseOrderProfile()
        {
            //TODO: 修改enum
            CreateMap<CreatePurchaseOrderCommand, PurchaseOrder>()
                .ForMember(
                    dest => dest.PurchaseOrderStatus,
                    opt => opt.MapFrom(src => 1)
                );
        }
    }
}
