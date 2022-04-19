using Domain.PurchaseOrderLines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context.Configurations
{
    public class PurchaseOrderLineConfiguration : IEntityTypeConfiguration<PurchaseOrderLine>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderLine> entity)
        {
            entity.HasOne(x => x.PurchaseOrder)
                .WithMany(x => x.PurchaseOrderLine)
                .HasForeignKey(x => x.PurchaseOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(x => x.Product)
                .WithMany(x => x.PurchaseOrderLine)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(x => x.Unit)
                .WithMany(x => x.PurchaseOrderLine)
                .HasForeignKey(x => x.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
