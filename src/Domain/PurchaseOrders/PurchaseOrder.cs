using Domain.Common;
using Domain.PurchaseOrderLines;
using Domain.Warehouses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PurchaseOrders
{
    public class PurchaseOrder : MyEntity<Guid>
    {
        [MaxLength(50)]
        public string SerialNumber { get; set; }

        public Guid WarehouseId { get; set; }

        [Required]
        public int PurchaseOrderStatus { get; set; }

        [Required]
        public DateTime PurchaseOrderDate { get; set; }


        [MaxLength(100)]
        public string Description { get; set; }



        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
