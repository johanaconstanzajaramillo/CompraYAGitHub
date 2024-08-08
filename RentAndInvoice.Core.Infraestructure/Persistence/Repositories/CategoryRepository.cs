using RentAndInvoice.Core.Domain.Entities.Products;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Infraestructure.Persistence.Repositories;

internal sealed class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void Update(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();
    }

    public void Remove(Category category)
    {
        _context.Categories.Remove(category);
        _context.SaveChanges();
    }

    public Category GetByIdAsync(CategoryId id)
    {
        return _context.Categories
            .FirstOrDefault(p => p.Id == id);
    }
}
