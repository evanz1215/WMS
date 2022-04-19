using Application.Common.Dependencies.DataAccess.Repositories;
using AutoMapper;
using Domain.Products;
using Domain.ProductTypes;
using Domain.Units;
using Infrastructure.ApplicationDependencies.DataAccess.Repositories.Common;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ApplicationDependencies.DataAccess.Repositories
{
    public class UnitRepository : RepositoryBase<Unit, int>, IUnitRepository
    {
        protected override IQueryable<Unit> BaseQuery => _dbContext.Unit;

        public UnitRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }



    }
}
