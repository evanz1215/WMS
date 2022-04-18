﻿using Application.Common.Dependencies.DataAccess;
using Application.Common.Dependencies.DataAccess.Repositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace Infrastructure.ApplicationDependencies.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IDbContextTransaction _currentTransaction;


        public IProductTypeRepository ProductType { get; set; }
        public IProductRepository Product { get; set; }

        public UnitOfWork(ApplicationDbContext dbContext,
            IProductTypeRepository productType, IProductRepository product)
        {
            _dbContext = dbContext;
            ProductType = productType;
            Product = product;
        }

        public void Dispose()
             => _dbContext.Dispose();

        public Task<int> SaveChangesAsync()
            => _dbContext.SaveChangesAsync();

        public bool HasActiveTransaction
            => _currentTransaction != null;

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                throw new InvalidOperationException("A transaction is already in progress.");
            }

            _currentTransaction = await _dbContext.Database.BeginTransactionAsync(IsolationLevel.RepeatableRead);
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();

                _currentTransaction?.Commit();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                await _currentTransaction?.RollbackAsync();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    await _currentTransaction.DisposeAsync();
                    _currentTransaction = null;
                }
            }
        }
    }
}