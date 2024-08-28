using Application.Abstractions.Repositories.Common;
using Application.Exceptions;
using MediatR;

namespace Application.Commands.Products.DeleteProducts;

public class DeleteProductsCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteProductsCommand, DeleteProductsCommandResponse>
{
    public async Task<DeleteProductsCommandResponse> Handle(DeleteProductsCommand request,
        CancellationToken cancellationToken)
    {
        await unitOfWork.BeginTransactionAsync(cancellationToken);


        foreach (var id in request.Ids)
        {
            var product = await unitOfWork.Products.GetByIdAsync(id, cancellationToken);

            if (product is null)
            {
                throw new NotFoundException("Product", id.Value);
            }

            await unitOfWork.Products.DeleteAsync(product);
        }
        
        try
        {
            await unitOfWork.CommitTransactionAsync(cancellationToken);

            return new DeleteProductsCommandResponse(true);
        }
        catch
        {
            return new DeleteProductsCommandResponse(false);
        }
    }
}