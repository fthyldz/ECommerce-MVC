using Domain.ValueObjects;

namespace Application.Queries.Discounts.GetDiscounts;

public record GetDiscountsCommandResponse(IReadOnlyList<DiscountDto> Discounts);

public record DiscountDto(
    Guid Id,
    Guid ProductId,
    string ProductName,
    Guid? RoleId,
    string? RoleName,
    decimal Rate);