using Application.Abstractions.Repositories.Common;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Abstractions.Repositories;

public interface IDiscountRepository : IGenericRepository<Discount, DiscountId>
{
    Task<IReadOnlyList<Discount>> GetAllWithProductAndRoleAsync(CancellationToken cancellationToken = default);
    
    Task<IReadOnlyList<Discount>> GetAllByRoleId(Guid roleId, CancellationToken cancellationToken = default);
    
    Task<Discount?> GetByProductIdAndRoleId(ProductId productId, Guid roleId, CancellationToken cancellationToken = default);
}