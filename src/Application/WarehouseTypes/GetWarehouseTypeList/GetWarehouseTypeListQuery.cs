using Application.Common.Dependencies.DataAccess;
using Application.Common.Dependencies.DataAccess.Repositories.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WarehouseTypes.GetWarehouseTypeList
{
    public class GetWarehouseTypeListQuery : ListQueryModel<WarehouseTypeListDto>
    {
        public string Name { get; set; }
    }

    public class GetWarehouseTypeListQueryHandler : IRequestHandler<GetWarehouseTypeListQuery, IListResponseModel<WarehouseTypeListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetWarehouseTypeListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IListResponseModel<WarehouseTypeListDto>> Handle(GetWarehouseTypeListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.WarehouseType.GetProjectedListDtoAsync(request);
            return result;

        }
    }
}
