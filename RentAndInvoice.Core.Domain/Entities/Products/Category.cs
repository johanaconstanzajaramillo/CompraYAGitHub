namespace RentAndInvoice.Core.Domain.Entities.Products;

public class Category
{
    public Category()
    {

    }
    public Category(CategoryId id, string name, bool enabled)
    {
        Id = id;
        Name = name;
        Enabled = enabled;
    }

    public CategoryId Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool Enabled { get; set; }


    public void Update(string name, bool enabled)
    {
        Name = name;
        Enabled = enabled;
    }
}
