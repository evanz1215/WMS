using Application.Common.Dependencies.DataAccess;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Units.GetUnit
{
    public class GetUnitQuery : IRequest<UnitDto>
    {
        public int Id { get; set; }
    }


    public class GetUnitQueryHandler : IRequestHandler<GetUnitQuery, UnitDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUnitQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UnitDto> Handle(GetUnitQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Unit.GetByIdAsync(request.Id);
            var resultDto = _mapper.Map<UnitDto>(result);

            return resultDto;

        }
    }
}
