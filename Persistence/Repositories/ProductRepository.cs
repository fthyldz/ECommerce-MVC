using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class ProductRepository(ApplicationDbContext context)
    : GenericRepository<Product, ProductId>(context), IProductRepository
{
    public async Task<IReadOnlyList<Product>> GetAllWithCategoryAsync(CancellationToken cancellationToken = default)
    {
        return await context.Products.Include(p => p.Category).ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Product>> GetAllWithCategoryByCategoryIdAsync(CategoryId? categoryId,
        CancellationToken cancellationToken = default)
    {
        if (categoryId is null) return await GetAllWithCategoryAsync(cancellationToken);
        return await context.Products.Where(p => p.CategoryId == categoryId).Include(p => p.Category)
            .ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetByIdWithCategoryAsync(ProductId id, CancellationToken cancellationToken = default)
    {
        return await context.Products.Where(p => p.Id == id).Include(p => p.Category)
            .FirstOrDefaultAsync(cancellationToken);
    }
}