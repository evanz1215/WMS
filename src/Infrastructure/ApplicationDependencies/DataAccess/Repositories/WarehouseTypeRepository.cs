using Application.Common.Dependencies.DataAccess.Repositories;
using AutoMapper;
using Domain.WarehouseTypes;
using Infrastructure.ApplicationDependencies.DataAccess.Repositories.Common;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ApplicationDependencies.DataAccess.Repositories
{
    public class WarehouseTypeRepository : RepositoryBase<WarehouseType, int>, IWarehouseTypeRepository
    {
        protected override IQueryable<WarehouseType> BaseQuery => _dbContext.WarehouseType;

        public WarehouseTypeRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
