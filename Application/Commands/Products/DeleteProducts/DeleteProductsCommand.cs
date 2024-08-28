using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.Products.DeleteProducts;

public record DeleteProductsCommand(IEnumerable<ProductId> Ids) : IRequest<DeleteProductsCommandResponse>;