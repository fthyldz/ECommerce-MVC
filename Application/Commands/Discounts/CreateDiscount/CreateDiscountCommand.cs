using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.Discounts.CreateDiscount;

public record CreateDiscountCommand(ProductId ProductId, Guid? RoleId, decimal Rate)
    : IRequest<CreateDiscountCommandResponse>;