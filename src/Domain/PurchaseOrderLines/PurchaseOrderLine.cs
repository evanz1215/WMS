using Domain.Common;
using Domain.Products;
using Domain.PurchaseOrders;
using Domain.Units;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PurchaseOrderLines
{
    public class PurchaseOrderLine : MyEntity<Guid>
    {
        public Guid PurchaseOrderId { get; set; }

        public Guid ProductId { get; set; }

        [Precision(18, 2)]
        public decimal Quantity { get; set; }

        public int UnitId { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
        public virtual Product Product { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
