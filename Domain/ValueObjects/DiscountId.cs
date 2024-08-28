using Domain.Exceptions;

namespace Domain.ValueObjects;

public record DiscountId
{
    public Guid Value { get; }

    private DiscountId(Guid value) => Value = value;

    public static DiscountId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("DiscountId cannot be empty.");
        }

        return new DiscountId(value);
    }
}