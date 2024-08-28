using MediatR;

namespace Application.Queries.Categories.GetCategories;

public record GetCategoriesQuery : IRequest<GetCategoriesQueryResponse>;