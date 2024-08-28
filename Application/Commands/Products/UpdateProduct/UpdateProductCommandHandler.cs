using Application.Abstractions.Repositories.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Products.UpdateProduct;

public class UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateProductCommand, UpdateProductCommandResponse>
{
    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request,
        CancellationToken cancellationToken)
    {
        await unitOfWork.BeginTransactionAsync(cancellationToken);

        var product = await unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
        {
            return new UpdateProductCommandResponse(false);
        }

        mapper.Map(request, product);

        await unitOfWork.Products.UpdateAsync(product);

        await unitOfWork.CommitTransactionAsync(cancellationToken);

        return new UpdateProductCommandResponse(true);
    }
}