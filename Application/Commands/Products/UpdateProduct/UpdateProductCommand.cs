using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.Products.UpdateProduct;

public record UpdateProductCommand(
    ProductId Id,
    string Name,
    string Description,
    Money Price,
    int StockQuantity,
    CategoryId CategoryId) : IRequest<UpdateProductCommandResponse>;