using Domain.Common;
using Domain.ProductTypes;
using Domain.PurchaseOrderLines;
using Domain.Units;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Products
{
    public class Product : MyEntity<Guid>
    {

        [MaxLength(50)]
        public string SerialNumber { get; set; }

        [Required, MinLength(1), MaxLength(50)]
        public string Name { get; set; }


        [Required]
        public int ProductTypeId { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }


        [Precision(18, 2)]
        public decimal BidPrice { get; set; }

        [Precision(18, 2)]
        public decimal AsKPrice { get; set; }

        [Required]
        public int BaseUnitId { get; set; }

        [Required]
        public bool IsEnable { get; set; }

        public virtual ProductType ProductType { get; set; }
        public virtual Unit Unit { get; set; }


        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }
    }
}
