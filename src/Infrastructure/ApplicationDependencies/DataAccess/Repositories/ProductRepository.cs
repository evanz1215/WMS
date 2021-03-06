using Application.Common.Dependencies.DataAccess.Repositories;
using AutoMapper;
using Domain.Products;
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
    public class ProductRepository : RepositoryBase<Product, Guid>, IProductRepository
    {
        protected override IQueryable<Product> BaseQuery => _dbContext.Product
            .Include(x => x.ProductType)
            .Include(x => x.Unit);

        public ProductRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }



    }
}
