using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PurchaseOrders.CreatePurchaseOrder
{
    public class PurchaseOrderLineFromPurchaseOrderForCreationDto
    {
        //public Guid PurchaseOrderId { get; set; }

        public Guid ProductId { get; set; }

        public decimal Quantity { get; set; }

        public int UnitId { get; set; }

    }
}
