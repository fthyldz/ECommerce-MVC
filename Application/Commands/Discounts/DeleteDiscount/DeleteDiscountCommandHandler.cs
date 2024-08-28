using Application.Abstractions.Repositories.Common;
using AutoMapper;
using MediatR;

namespace Application.Commands.Discounts.DeleteDiscount;

public class DeleteDiscountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteDiscountCommand, DeleteDiscountCommandResponse>
{
    public async Task<DeleteDiscountCommandResponse> Handle(DeleteDiscountCommand request,
        CancellationToken cancellationToken)
    {
        await unitOfWork.BeginTransactionAsync(cancellationToken);

        var discount = await unitOfWork.Discounts.GetByIdAsync(request.Id, cancellationToken);

        if (discount is null)
        {
            return new DeleteDiscountCommandResponse(false);
        }

        await unitOfWork.Discounts.DeleteAsync(discount);

        await unitOfWork.CommitTransactionAsync(cancellationToken);

        return new DeleteDiscountCommandResponse(true);
    }
}