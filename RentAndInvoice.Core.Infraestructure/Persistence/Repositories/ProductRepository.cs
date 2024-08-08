using Microsoft.EntityFrameworkCore;
using RentAndInvoice.Core.Domain.Entities.Products;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Infraestructure.Persistence.Repositories;

internal sealed class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Update(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void Remove(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public Product GetByIdAsync(ProductId id)
    {
        return _context.Products
            .FirstOrDefault(p => p.Id == id);
    }
}
