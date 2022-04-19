using Application.Common.Dependencies.DataAccess.Repositories;
using AutoMapper;
using Domain.PurchaseOrders;
using Infrastructure.ApplicationDependencies.DataAccess.Repositories.Common;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ApplicationDependencies.DataAccess.Repositories
{
    public class PurchaseOrderRepository : RepositoryBase<PurchaseOrder, Guid>, IPurchaseOrderRepository
    {
        protected override IQueryable<PurchaseOrder> BaseQuery => _dbContext.PurchaseOrder
            .Include(x => x.Warehouse)
                .ThenInclude(x => x.WarehouseType)
            .Include(x => x.PurchaseOrderLine)
                .ThenInclude(x => x.Product)
                    .ThenInclude(x => x.ProductType)
            .Include(x => x.PurchaseOrderLine)
                .ThenInclude(x => x.Unit);

        public PurchaseOrderRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
