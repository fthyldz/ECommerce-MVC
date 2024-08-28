namespace Application.Queries.Categories.GetCategories;

public record GetCategoriesQueryResponse(IReadOnlyList<CategoryDto> Categories);

public record CategoryDto(Guid Id, string Name);