using Application.Common.Dependencies.DataAccess;
using Application.Common.Dependencies.DataAccess.Repositories.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PurchaseOrders.GetPurchaseOrderList
{
    public class GetPurchaseOrderListQuery : ListQueryModel<PurchaseOrderListDto>
    {
        public string SerialNumber { get; set; }
        public Guid? WarehouseId { get; set; }
        public int? PurchaseOrderStatus { get; set; }
        public DateTime? PurchaseOrderDate { get; set; }
    }


    public class GetPurchaseOrderListQueryHandler : IRequestHandler<GetPurchaseOrderListQuery, IListResponseModel<PurchaseOrderListDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPurchaseOrderListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IListResponseModel<PurchaseOrderListDto>> Handle(GetPurchaseOrderListQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.PurchaseOrder.GetProjectedListDtoAsync(request);

            return result;
        }
    }
}
