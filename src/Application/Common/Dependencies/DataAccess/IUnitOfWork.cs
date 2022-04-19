using Application.Common.Dependencies.DataAccess.Repositories;

namespace Application.Common.Dependencies.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {

        public IProductTypeRepository ProductType { get; set; }
        public IProductRepository Product { get; set; }
        public IUnitRepository Unit { get; set; }
        public IPurchaseOrderRepository PurchaseOrder { get; set; }
        public IPurchaseOrderLineRepository PurchaseOrderLine { get; set; }
        public IWarehouseTypeRepository WarehouseType { get; set; }
        public IWarehouseRepository Warehouse { get; set; }

        bool HasActiveTransaction { get; }

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();

        Task<int> SaveChangesAsync();
    }
}