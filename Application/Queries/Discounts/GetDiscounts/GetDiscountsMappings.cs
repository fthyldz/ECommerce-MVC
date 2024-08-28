using AutoMapper;
using Domain.ValueObjects;

namespace Application.Queries.Discounts.GetDiscounts;

public class GetDiscountsMappings : Profile
{
    public GetDiscountsMappings()
    {
        CreateMap<Guid, DiscountId>().ConvertUsing(s => DiscountId.Of(s));
        CreateMap<DiscountId, Guid>().ConvertUsing(s => s.Value);
        CreateMap<Domain.Entities.Discount, DiscountDto>()
            .ConstructUsing(s => new DiscountDto(s.Id.Value, s.ProductId.Value,
                s.Product.Name, s.RoleId,
                s.Role != null ? s.Role.Name : null, s.Rate));
    }
}