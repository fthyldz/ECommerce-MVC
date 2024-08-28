using MediatR;

namespace Application.Queries.Products.GetProducts;

public record GetProductsQuery(string RoleName) : IRequest<GetProductsQueryResponse>;