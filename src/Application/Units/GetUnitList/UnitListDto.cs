using Application.Common.Mapping;
using Domain.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Units.GetUnitList
{
    public class UnitListDto : IMapFrom<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
