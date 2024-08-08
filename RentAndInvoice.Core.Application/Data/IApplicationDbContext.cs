using Microsoft.EntityFrameworkCore;
using RentAndInvoice.Core.Domain.Entities.Customers;
using RentAndInvoice.Core.Domain.Entities.General;
using RentAndInvoice.Core.Domain.Entities.Products;
using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.Application.Data;

public interface IApplicationDbContext
{
   public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<User> Users { get; set; }
}
