using Application.Common.Mapping;
using Domain.Warehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Warehouses.GetWarehouseList
{
    public class WarehouseListDto : IMapFrom<Warehouse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
