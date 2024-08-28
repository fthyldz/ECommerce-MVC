using Application.Abstractions.Repositories.Common;
using AutoMapper;
using MediatR;

namespace Application.Queries.Categories.GetCategories;

public class GetCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetCategoriesQuery, GetCategoriesQueryResponse>
{
    public async Task<GetCategoriesQueryResponse> Handle(GetCategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var categories = await unitOfWork.Categories.GetAllAsync(cancellationToken);
        var categoriesDto = mapper.Map<IReadOnlyList<CategoryDto>>(categories);
        return new GetCategoriesQueryResponse(categoriesDto);
    }
}