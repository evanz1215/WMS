using Application.Common.Dependencies.DataAccess.Repositories;
using AutoMapper;
using Domain.PurchaseOrderLines;
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
    public class PurchaseOrderLineRepository : RepositoryBase<PurchaseOrderLine, Guid>, IPurchaseOrderLineRepository
    {

        protected override IQueryable<PurchaseOrderLine> BaseQuery => _dbContext.PurchaseOrderLine
            .Include(x => x.Product)
                .ThenInclude(x => x.ProductType)
            .Include(x => x.Unit);

        public PurchaseOrderLineRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }

}
