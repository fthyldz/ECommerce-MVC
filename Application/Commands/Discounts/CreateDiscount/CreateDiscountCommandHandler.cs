using Application.Abstractions.Repositories.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Discounts.CreateDiscount;

public class CreateDiscountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateDiscountCommand, CreateDiscountCommandResponse>
{
    public async Task<CreateDiscountCommandResponse> Handle(CreateDiscountCommand request,
        CancellationToken cancellationToken)
    {
        await unitOfWork.BeginTransactionAsync(cancellationToken);

        var discount = mapper.Map<Discount>(request);

        await unitOfWork.Discounts.AddAsync(discount, cancellationToken);

        await unitOfWork.CommitTransactionAsync(cancellationToken);

        return new CreateDiscountCommandResponse(true);
    }
}