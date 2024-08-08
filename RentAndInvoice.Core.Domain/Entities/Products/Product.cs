namespace RentAndInvoice.Core.Domain.Entities.Products;

public class Product
{
    public Product(ProductId id, string name, Money price, int ammountStock, Category category, bool enabled)
    {
        Id = id;
        Name = name;
        Price = price;
        AmmountStock = ammountStock;
        Category = category;
        Enabled = enabled;  
    }
    private Product()
    {
    }

    public ProductId Id { get; private set; }

    public string Name { get; set; } = string.Empty;

    public Money Price { get; private set; }

    public int AmmountStock { get; set; }
    public bool Enabled { get; set; }

    public Category Category { get; set; }

    public void Update(string name, Money price, int ammountStock, Category category, bool enabled)
    {
        Name = name;
        Price = price;
        AmmountStock = ammountStock;
        Category = category;
        Enabled = enabled;
    }
}
