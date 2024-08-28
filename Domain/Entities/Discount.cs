using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Discount : BaseEntity<DiscountId>
{
    public ProductId ProductId { get; private set; }
    public Product Product { get; private set; }
    public Guid? RoleId { get; private set; }
    public Role? Role { get; private set; }
    public decimal Rate { get; private set; }

    private Discount()
    {
    }

    public Discount(DiscountId id, ProductId productId, Guid? roleId, decimal rate)
    {
        Id = id;
        ProductId = productId;
        RoleId = roleId;
        Rate = rate;
    }
}