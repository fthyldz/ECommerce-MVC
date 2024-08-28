using Application.Commands.Discounts.CreateDiscount.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Commands.Discounts.CreateDiscount;

public class CreateDiscountMappings : Profile
{
    public CreateDiscountMappings()
    {
        CreateMap<CreateDiscountRequestDto, CreateDiscountCommand>();
        CreateMap<CreateDiscountCommand, Discount>()
            .ForMember(d => d.RoleId, opt => opt.MapFrom(c => c.RoleId.HasValue && c.RoleId.Value == Guid.Empty ? null : c.RoleId))
            .ConstructUsing(c =>
                new Discount(DiscountId.Of(Guid.NewGuid()), c.ProductId, c.RoleId.HasValue && c.RoleId.Value == Guid.Empty ? null : c.RoleId,
                    c.Rate));
        CreateMap<CreateDiscountCommandResponse, CreateDiscountResponseDTO>();
    }
}