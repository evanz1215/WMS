using Domain.Common;
using Domain.Products;
using Domain.PurchaseOrderLines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Units
{
    public class Unit : BaseEntity<int>
    {
        public string Name { get; set; }


        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }
    }
}
