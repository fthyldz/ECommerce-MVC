using Application.Abstractions.Repositories;
using Application.Abstractions.Repositories.Common;
using Microsoft.EntityFrameworkCore.Storage;
using Persistence.Context;

namespace Persistence.Repositories.Common;

public class UnitOfWork(
    ApplicationDbContext context,
    ICategoryRepository categoryRepository,
    IProductRepository productRepository,
    IDiscountRepository discountRepository) : IUnitOfWork
{
    private IDbContextTransaction? _transaction;

    public ICategoryRepository Categories { get; } = categoryRepository;
    public IProductRepository Products { get; } = productRepository;
    public IDiscountRepository Discounts { get; } = discountRepository;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        _transaction = await context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await SaveChangesAsync(cancellationToken);
            await _transaction?.CommitAsync(cancellationToken)!;
        }
        catch
        {
            await RollbackTransactionAsync(cancellationToken);
            throw;
        }
        finally
        {
            _transaction?.Dispose();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync(cancellationToken);
            _transaction.Dispose();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            context.Dispose();
        }
    }
}