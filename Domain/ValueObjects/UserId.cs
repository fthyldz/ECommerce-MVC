using Domain.Exceptions;

namespace Domain.ValueObjects;

public readonly record struct UserId
{
    public Guid Value { get; }

    private UserId(Guid value) => Value = value;

    public static UserId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("UserId cannot be empty.");
        }

        return new UserId(value);
    }
}