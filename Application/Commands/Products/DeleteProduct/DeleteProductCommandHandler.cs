using Application.Abstractions.Repositories.Common;
using Application.Exceptions;
using MediatR;

namespace Application.Commands.Products.DeleteProduct;

public class DeleteProductCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteProductCommand, DeleteProductCommandResponse>
{
    public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommand request,
        CancellationToken cancellationToken)
    {
        await unitOfWork.BeginTransactionAsync(cancellationToken);

        var product = await unitOfWork.Products.GetByIdAsync(request.Id, cancellationToken);

        if (product is null)
        {
            throw new NotFoundException("Product", request.Id.Value);
        }

        await unitOfWork.Products.DeleteAsync(product);

        try
        {
            await unitOfWork.CommitTransactionAsync(cancellationToken);

            return new DeleteProductCommandResponse(true);
        }
        catch
        {
            return new DeleteProductCommandResponse(false);
        }
    }
}