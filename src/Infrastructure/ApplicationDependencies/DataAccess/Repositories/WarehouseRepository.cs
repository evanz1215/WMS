using Application.Common.Dependencies.DataAccess.Repositories;
using AutoMapper;
using Domain.Warehouses;
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
    public class WarehouseRepository : RepositoryBase<Warehouse, Guid>, IWarehouseRepository
    {
        protected override IQueryable<Warehouse> BaseQuery => _dbContext.Warehouse
            .Include(x => x.WarehouseType);

        public WarehouseRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
