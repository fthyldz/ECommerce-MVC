using Application.Commands.Products.UpdateProduct.DTOs;
using Application.Queries.Products.GetProducts;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Commands.Products.UpdateProduct;

public class UpdateProductMappings : Profile
{
    public UpdateProductMappings()
    {
        CreateMap<ProductDto, UpdateProductRequestDto>().ReverseMap();
        CreateMap<UpdateProductRequestDto, UpdateProductCommand>()
            .ForMember(d => d.Price, opt => opt.MapFrom(s => new Money(s.Price, s.Currency)))
            .ConstructUsing(s => new UpdateProductCommand(
                ProductId.Of(s.Id),
                s.Name,
                s.Description,
                new Money(s.Price, s.Currency),
                s.StockQuantity,
                CategoryId.Of(s.CategoryId)
            ));
        CreateMap<UpdateProductCommand, Product>()
            .ConstructUsing(s => new Product(
                s.Id,
                s.Name,
                s.Description,
                s.Price,
                s.StockQuantity,
                s.CategoryId
            ));
        CreateMap<UpdateProductCommandResponse, UpdateProductResponseDto>();
    }
}