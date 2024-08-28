using Application.Abstractions.Repositories.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Commands.Categories.CreateCategory;

public class CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        await unitOfWork.BeginTransactionAsync(cancellationToken);

        var category = mapper.Map<Category>(request);

        await unitOfWork.Categories.AddAsync(category, cancellationToken);

        await unitOfWork.CommitTransactionAsync(cancellationToken);

        return new CreateCategoryCommandResponse(true);
    }
}