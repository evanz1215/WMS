using Application.Common.Dependencies.DataAccess;
using Application.Common.Dependencies.DataAccess.Repositories.Common;
using MediatR;

namespace Application.Warehouses.GetWarehouseList
{
    public class GetWarehouseListQuery : ListQueryModel<WarehouseListDto>
    {
        public string Name { get; set; }
    }

    public class GetWarehouseListQueryHandler : IRequestHandler<GetWarehouseListQuery, IListResponseModel<WarehouseListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetWarehouseListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IListResponseModel<WarehouseListDto>> Handle(GetWarehouseListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Warehouse.GetProjectedListDtoAsync(request);

            return result;
        }
    }
}