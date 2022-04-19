using Application.Units.CreateUnit;
using Application.Units.GetUnit;
using Application.Units.PatchUnit;
using AutoMapper;
using Domain.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Units.Common
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            CreateMap<Unit, UnitDto>();
            CreateMap<CreateUnitCommand, Unit>();
            CreateMap<UnitForUpdateDto, Unit>().ReverseMap();
        }
    }
}
