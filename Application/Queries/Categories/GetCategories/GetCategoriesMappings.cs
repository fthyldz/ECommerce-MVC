using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Queries.Categories.GetCategories;

public class GetCategoriesMappings : Profile
{
    public GetCategoriesMappings()
    {
        CreateMap<CategoryId, Guid>().ConvertUsing(s => s.Value);
        CreateMap<Guid, CategoryId>().ConvertUsing(s => CategoryId.Of(s));
        CreateMap<Category, CategoryDto>();
    }
}