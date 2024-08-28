using Application.Abstractions.Repositories.Common;
using Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Application.Commands.Categories.DeleteCategory;

public class DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse>
{
    public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommand request,
        CancellationToken cancellationToken)
    {
        await unitOfWork.BeginTransactionAsync(cancellationToken);

        var category = await unitOfWork.Categories.GetByIdAsync(request.Id, cancellationToken);

        if (category is null)
        {
            throw new NotFoundException("Category", request.Id.Value);
        }

        await unitOfWork.Categories.DeleteAsync(category);

        try
        {
            await unitOfWork.CommitTransactionAsync(cancellationToken);

            return new DeleteCategoryCommandResponse(true);
        }
        catch
        {
            return new DeleteCategoryCommandResponse(false);
        }
    }
}