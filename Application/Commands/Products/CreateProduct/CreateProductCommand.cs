using Domain.Enums;
using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    CurrencyType Currency,
    int StockQuantity,
    CategoryId CategoryId) : IRequest<CreateProductCommandResponse>;