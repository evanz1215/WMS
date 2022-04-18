using Application.Common.Dependencies.DataAccess.Repositories;

namespace Application.Common.Dependencies.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {

        public IProductTypeRepository ProductType { get; set; }
        public IProductRepository Product { get; set; }

        bool HasActiveTransaction { get; }

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();

        Task<int> SaveChangesAsync();
    }
}