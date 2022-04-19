using Application.Common.Mapping;
using Domain.PurchaseOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PurchaseOrders.GetPurchaseOrderList
{
    public class PurchaseOrderListDto : IMapFrom<PurchaseOrder>
    {
        public Guid Id { get; set; }
    }
}
