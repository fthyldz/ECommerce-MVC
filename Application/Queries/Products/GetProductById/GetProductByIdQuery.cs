using Domain.ValueObjects;
using MediatR;

namespace Application.Queries.Products.GetProductById;

public record GetProductByIdQuery(ProductId ProductId, string RoleName) : IRequest<GetProductByIdQueryResponse>;