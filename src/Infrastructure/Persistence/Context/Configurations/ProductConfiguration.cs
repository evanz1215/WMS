using Domain.Products;
using Domain.ProductTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasOne(x => x.ProductType)
                .WithMany(x => x.Product)
                .HasForeignKey(x => x.ProductTypeId);


            entity.HasOne(x => x.Unit)
                .WithMany(x => x.Product)
                .HasForeignKey(x => x.BaseUnitId);
        }
    }
}
