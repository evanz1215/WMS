using Application.Common.Dependencies.DataAccess;
using Application.Common.Dependencies.DataAccess.Repositories.Common;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Units.GetUnitList
{
    public class GetUnitListQuery : ListQueryModel<UnitListDto>
    {
        public string Name { get; set; }
    }


    public class GetUnitListQueryHandler : IRequestHandler<GetUnitListQuery, IListResponseModel<UnitListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetUnitListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IListResponseModel<UnitListDto>> Handle(GetUnitListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Unit.GetProjectedListDtoAsync(request, readOnly: true);
            return result;
        }
    }
}
