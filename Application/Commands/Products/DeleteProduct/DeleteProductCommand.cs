using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.Products.DeleteProduct;

public record DeleteProductCommand(ProductId Id) : IRequest<DeleteProductCommandResponse>;