using Application.Commands.Categories.DeleteCategory.DTOs;
using Application.Commands.Discounts.DeleteDiscount.DTOs;
using AutoMapper;
using Domain.ValueObjects;

namespace Application.Commands.Discounts.DeleteDiscount;

public class DeleteDiscountMappings : Profile
{
    public DeleteDiscountMappings()
    {
        CreateMap<Guid, DiscountId>().ConvertUsing(s => DiscountId.Of(s));
        CreateMap<DeleteCategoryRequestDto, DeleteDiscountCommand>();
        CreateMap<DeleteDiscountCommandResponse, DeleteDiscountResponseDto>();
    }
}