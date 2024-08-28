using Domain.Enums;

namespace Application.Queries.Products.GetProducts;

public record GetProductsQueryResponse(IReadOnlyList<ProductDto> Products);

public record ProductDto
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

    public ProductDto(Guid id, string name, string description, decimal price, CurrencyType currency,
        string currencyString, int stockQuantity, Guid categoryId, string categoryName)
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
    }
}