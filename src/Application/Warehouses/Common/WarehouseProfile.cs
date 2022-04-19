using Application.Warehouses.CreateWarehouse;
using AutoMapper;
using Domain.Warehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Warehouses.Common
{
    public class WarehouseProfile: Profile
    {
        public WarehouseProfile()
        {
            CreateMap<CreateWarehouseCommand, Warehouse>();
        }
    }
}
