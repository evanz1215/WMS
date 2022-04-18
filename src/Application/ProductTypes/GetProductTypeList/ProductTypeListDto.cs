using Application.Common.Mapping;
using Domain.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProductTypes.GetProductTypeList
{
    public class ProductTypeListDto : IMapFrom<ProductType>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
