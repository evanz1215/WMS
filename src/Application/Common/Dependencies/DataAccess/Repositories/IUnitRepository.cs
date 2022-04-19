using Application.Common.Dependencies.DataAccess.Repositories.Common;
using Domain.Products;
using Domain.ProductTypes;
using Domain.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dependencies.DataAccess.Repositories
{
    public interface IUnitRepository : IRepositoryBase<Unit, int>
    {
    }
}
