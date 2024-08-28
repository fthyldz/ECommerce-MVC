using Application.Commands.Categories.CreateCategory.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Commands.Categories.CreateCategory;

public class CreateCategoryMappings : Profile
{
    public CreateCategoryMappings()
    {
        CreateMap<CreateCategoryRequestDto, CreateCategoryCommand>();
        CreateMap<CreateCategoryCommand, Category>()
            .ConstructUsing(c => new Category(CategoryId.Of(Guid.NewGuid()), c.Name));
        CreateMap<Category, CreateCategoryCommandResponse>();
        CreateMap<CreateCategoryCommandResponse, CreateCategoryResponseDto>();
    }
}