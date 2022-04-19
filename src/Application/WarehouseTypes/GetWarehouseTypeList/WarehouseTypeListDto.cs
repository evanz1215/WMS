using Application.Common.Mapping;
using Domain.WarehouseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WarehouseTypes.GetWarehouseTypeList
{
    public class WarehouseTypeListDto : IMapFrom<WarehouseType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
