using Application.Abstractions.Repositories.Common;
using AutoMapper;
using MediatR;

namespace Application.Queries.Discounts.GetDiscounts;

public class GetDiscountsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetDiscountsCommand, GetDiscountsCommandResponse>
{
    public async Task<GetDiscountsCommandResponse> Handle(GetDiscountsCommand request,
        CancellationToken cancellationToken)
    {
        var discounts = await unitOfWork.Discounts.GetAllWithProductAndRoleAsync(cancellationToken);

        var discountsDto = mapper.Map<IReadOnlyList<DiscountDto>>(discounts);

        return new GetDiscountsCommandResponse(discountsDto);
    }
}