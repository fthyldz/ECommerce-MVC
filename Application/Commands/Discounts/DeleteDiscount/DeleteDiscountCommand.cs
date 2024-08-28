using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.Discounts.DeleteDiscount;

public record DeleteDiscountCommand(DiscountId Id) : IRequest<DeleteDiscountCommandResponse>;