using Application.Abstractions.Repositories.Common;
using Application.Queries.Categories.GetCategories;
using AutoMapper;
using MediatR;

namespace Application.Queries.Categories.GetCategoryById;

public class GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResponse>
{
    public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQuery request,
        CancellationToken cancellationToken)
    {
        var category = await unitOfWork.Categories.GetByIdAsync(request.Id, cancellationToken);
        var categoriesDto = mapper.Map<CategoryDto>(category);
        return new GetCategoryByIdQueryResponse(categoriesDto);
    }
}