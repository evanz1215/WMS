using Application.Common.Dependencies.DataAccess.Repositories;
using AutoMapper;
using Domain.Products;
using Domain.ProductTypes;
using Infrastructure.ApplicationDependencies.DataAccess.Repositories.Common;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ApplicationDependencies.DataAccess.Repositories
{
    public class ProductTypeRepository : RepositoryBase<ProductType, int>, IProductTypeRepository
    {
        protected override IQueryable<ProductType> BaseQuery => _dbContext.ProductType;

        public ProductTypeRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }



    }
}
