using Application.Commands.Categories.DeleteCategory.DTOs;
using AutoMapper;
using Domain.ValueObjects;

namespace Application.Commands.Categories.DeleteCategory;

public class DeleteCategoryMappings : Profile
{
    public DeleteCategoryMappings()
    {
        CreateMap<DeleteCategoryRequestDto, DeleteCategoryCommand>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => CategoryId.Of(s.Id)));
    }
}