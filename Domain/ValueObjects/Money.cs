using Domain.Enums;

namespace Domain.ValueObjects;

public record Money(decimal Price, CurrencyType Currency);