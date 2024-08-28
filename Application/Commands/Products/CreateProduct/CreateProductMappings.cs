using Application.Commands.Products.CreateProduct.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Commands.Products.CreateProduct;

public class CreateProductMappings : Profile
{
    public CreateProductMappings()
    {
        CreateMap<Guid, CategoryId>().ConvertUsing(s => CategoryId.Of(s));
        CreateMap<CreateProductRequestDto, CreateProductCommand>();
        CreateMap<CreateProductCommand, Product>()
            .ForMember(d => d.Price, opt => opt.MapFrom(s => new Money(s.Price, s.Currency)))
            .ConstructUsing(s => new Product(
                ProductId.Of(Guid.NewGuid()),
                s.Name,
                s.Description,
                new Money(s.Price, s.Currency),
                s.StockQuantity,
                s.CategoryId
            ));
    }
}