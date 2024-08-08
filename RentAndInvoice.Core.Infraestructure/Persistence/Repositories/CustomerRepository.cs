using RentAndInvoice.Core.Domain.Entities.Customers;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Infraestructure.Persistence.Repositories;

internal sealed class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
    }

    public void Update(Customer customer)
    {
        _context.Customers.Update(customer);
        _context.SaveChanges();
    }

    public void Remove(Customer customer)
    {
        _context.Customers.Remove(customer);
        _context.SaveChanges();
    }

    public Customer GetByIdAsync(CustomerId id)
    {
        return _context.Customers
            .FirstOrDefault(p => p.Id == id);
    }
}
