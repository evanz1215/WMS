using Application.Common.Dependencies.DataAccess.Repositories.Common;
using Domain.PurchaseOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dependencies.DataAccess.Repositories
{
    public interface IPurchaseOrderRepository : IRepositoryBase<PurchaseOrder, Guid>
    {
    }
}
