using Application.Abstractions.Repositories.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Abstractions.Repositories;

public interface IProductRepository : IGenericRepository<Product, ProductId>
{
    Task<IReadOnlyList<Product>> GetAllWithCategoryAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Product>> GetAllWithCategoryByCategoryIdAsync(CategoryId? categoryId,
        CancellationToken cancellationToken = default);

    Task<Product?> GetByIdWithCategoryAsync(ProductId id, CancellationToken cancellationToken = default);
}