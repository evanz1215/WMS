using Application.Common.Dependencies.DataAccess.Repositories.Common;
using Domain.WarehouseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dependencies.DataAccess.Repositories
{
    public interface IWarehouseTypeRepository : IRepositoryBase<WarehouseType, int>
    {
    }
}
