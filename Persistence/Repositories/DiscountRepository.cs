using Application.Abstractions.Repositories;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.Common;

namespace Persistence.Repositories;

public class DiscountRepository(ApplicationDbContext context)
    : GenericRepository<Discount, DiscountId>(context), IDiscountRepository
{
    public async Task<IReadOnlyList<Discount>> GetAllWithProductAndRoleAsync(
        CancellationToken cancellationToken = default)
    {
        return await context.Discounts.Include(d => d.Product).Include(d => d.Role).ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Discount>> GetAllByRoleId(Guid roleId,
        CancellationToken cancellationToken = default)
    {
        return (await context.Discounts.Where(d => !d.RoleId.HasValue || d.RoleId == roleId)
                .ToListAsync(cancellationToken))
            .GroupBy(d => new { d.ProductId }, d => d.Rate)
            .Select(d => new Discount(DiscountId.Of(Guid.NewGuid()), d.Key.ProductId, null, d.Max())).ToList();
    }

    public async Task<Discount?> GetByProductIdAndRoleId(ProductId productId, Guid roleId,
        CancellationToken cancellationToken = default)
    {
        return (await context.Discounts.Where(
                d => d.ProductId == productId && (!d.RoleId.HasValue || d.RoleId == roleId))
            .ToListAsync(cancellationToken)).MaxBy(d => d.Rate);
    }
}