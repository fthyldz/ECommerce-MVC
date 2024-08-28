using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Category : BaseEntity<CategoryId>
{
    private List<Product> _products = [];
    public string Name { get; private set; } = default!;
    public IReadOnlyList<Product> Products => _products.AsReadOnly();

    private Category()
    {
    }
    
    public Category(CategoryId id, string name)
    {
        Id = id;
        Name = name;
    }
}