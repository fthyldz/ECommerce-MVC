using Domain.ValueObjects;
using MediatR;

namespace Application.Queries.Categories.GetCategoryById;

public record GetCategoryByIdQuery(CategoryId Id) : IRequest<GetCategoryByIdQueryResponse>;