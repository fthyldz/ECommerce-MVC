using Application.Queries.Products.GetProducts;
using Domain.Enums;

namespace Application.Queries.Products.GetProductsByCategory;

public record GetProductsByCategoryQueryResponse(IReadOnlyList<ProductCheckableDto> Products);

public class ProductCheckableDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public CurrencyType Currency { get; set; }
    public string CurrencyString { get; set; }
    public int StockQuantity { get; set; }
    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; }
    public bool IsSelected { get; set; }

    public ProductCheckableDto()
    {
    }

    public ProductCheckableDto(Guid id, string name, string description, decimal price, CurrencyType currency,
        string currencyString, int stockQuantity, Guid categoryId, string categoryName, bool isSelected)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Currency = currency;
        CurrencyString = currencyString;
        StockQuantity = stockQuantity;
        CategoryId = categoryId;
        CategoryName = categoryName;
        IsSelected = isSelected;
    }
}