using Domain.Common;
using Domain.WarehouseTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Warehouses
{
    public class Warehouse : MyEntity<Guid>
    {

        [MaxLength(50)]
        public string SerialNumber { get; set; }

        [Required, MinLength(1), MaxLength(50)]
        public string Name { get; set; }


        [Required]
        public int WarehouseTypeId { get; set; }

        [Required]
        public bool IsEnable { get; set; }


        public virtual WarehouseType WarehouseType { get; set; }
    }
}
