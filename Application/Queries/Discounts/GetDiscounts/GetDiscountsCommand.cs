using MediatR;

namespace Application.Queries.Discounts.GetDiscounts;

public record GetDiscountsCommand() : IRequest<GetDiscountsCommandResponse>;