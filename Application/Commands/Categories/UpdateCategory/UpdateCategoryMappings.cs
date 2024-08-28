using Application.Commands.Categories.UpdateCategory.DTOs;
using Application.Queries.Categories.GetCategories;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Commands.Categories.UpdateCategory;

public class UpdateCategoryMappings : Profile
{
    public UpdateCategoryMappings()
    {
        CreateMap<CategoryDto, UpdateCategoryRequestDto>().ReverseMap();
        CreateMap<UpdateCategoryRequestDto, UpdateCategoryCommand>();
        CreateMap<UpdateCategoryCommand, Category>()
            .ConstructUsing(c => new Category(CategoryId.Of(Guid.NewGuid()), c.Name));
        CreateMap<UpdateCategoryCommandResponse, UpdateCategoryResponseDto>();
    }
}