using AutoMapper;
using Domain.Entities;

namespace Application.Queries.Products.GetProductsByCategory;

public class GetProductsByCategoryMappings : Profile
{
    public GetProductsByCategoryMappings()
    {
        CreateMap<Product, ProductCheckableDto>()
            .ForMember(d => d.Price, opt => opt.Ignore())
            .ConstructUsing(s => new ProductCheckableDto(s.Id.Value, s.Name, s.Description, s.Price.Price,
                s.Price.Currency,
                s.Price.Currency.ToString(), s.StockQuantity, s.Category.Id.Value, s.Category.Name, false));
    }
}