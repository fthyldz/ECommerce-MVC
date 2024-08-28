using Domain.ValueObjects;
using MediatR;

namespace Application.Queries.Products.GetProductsByCategory;

public record GetProductsByCategoryQuery(CategoryId? CategoryId, string RoleName) : IRequest<GetProductsByCategoryQueryResponse>;