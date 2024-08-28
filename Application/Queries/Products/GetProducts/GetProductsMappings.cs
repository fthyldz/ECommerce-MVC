using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Queries.Products.GetProducts;

public class GetProductsMappings : Profile
{
    public GetProductsMappings()
    {
        CreateMap<ProductId, Guid>().ConvertUsing(s => s.Value);
        CreateMap<Guid, ProductId>().ConvertUsing(s => ProductId.Of(s));
        CreateMap<Product, ProductDto>()
            .ForMember(d => d.Price, opt => opt.Ignore())
            .ConstructUsing(s => new ProductDto(s.Id.Value, s.Name, s.Description, s.Price.Price, s.Price.Currency,
                s.Price.Currency.ToString(), s.StockQuantity, s.Category.Id.Value, s.Category.Name));
    }
}