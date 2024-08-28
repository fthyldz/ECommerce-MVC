using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Product : BaseEntity<ProductId>
{
    public string Name { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public Money Price { get; private set; } = default!;
    public int StockQuantity { get; private set; } = default!;
    public CategoryId CategoryId { get; private set; }
    public Category Category { get; private set; }
    
    private Product()
    {
    }
    
    public Product(ProductId id, string name, string description, Money price, int stockQuantity, CategoryId categoryId)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        StockQuantity = stockQuantity;
        CategoryId = categoryId;
    }
}