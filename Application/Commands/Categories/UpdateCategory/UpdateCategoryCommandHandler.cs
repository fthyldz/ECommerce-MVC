using Application.Abstractions.Repositories.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Categories.UpdateCategory;

public class UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>
{
    public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        await unitOfWork.BeginTransactionAsync(cancellationToken);
        
        var category = await unitOfWork.Categories.GetByIdAsync(request.Id, cancellationToken);
        
        if (category is null)
        {
            return new UpdateCategoryCommandResponse(false);
        }
        
        mapper.Map(request, category);

        await unitOfWork.Categories.UpdateAsync(category);

        await unitOfWork.CommitTransactionAsync(cancellationToken);

        return new UpdateCategoryCommandResponse(true);
    }
}