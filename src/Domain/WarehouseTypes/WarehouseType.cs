using Domain.Common;
using Domain.Warehouses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.WarehouseTypes
{
    public class WarehouseType : BaseEntity<int>
    {

        [Required, MinLength(1), MaxLength(50)]
        public string Name { get; set; }


        public virtual ICollection<Warehouse> Warehouse { get; set; }
    }
}
