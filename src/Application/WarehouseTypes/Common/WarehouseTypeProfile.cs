using Application.WarehouseTypes.CreateWarehouseType;
using AutoMapper;
using Domain.WarehouseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WarehouseTypes.Common
{
    public  class WarehouseTypeProfile:Profile
    {
        public WarehouseTypeProfile()
        {
            CreateMap<CreateWarehouseTypeCommand, WarehouseType>();
        }
    }
}
