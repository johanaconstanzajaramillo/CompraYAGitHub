using Microsoft.EntityFrameworkCore;
using RentAndInvoice.Core.Application.Data;
using RentAndInvoice.Core.Domain.Entities.Customers;
using RentAndInvoice.Core.Domain.Entities.General;
using RentAndInvoice.Core.Domain.Entities.Products;
using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.Infraestructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.Entity<Customer>()
          .Property(c => c.Id)
          .HasConversion(
              id => id.Value,
              value => new CustomerId(value)
          );
        modelBuilder.Entity<Address>()
          .Property(c => c.Id)
          .HasConversion(
              id => id.Value,
              value => new AddressId(value)
          );
        modelBuilder.Entity<DocumentType>()
          .Property(c => c.Id)
          .HasConversion(
              id => id.Value,
              value => new DocumentTypeId(value)
          );

        modelBuilder.Entity<Phone>()
          .Property(c => c.Id)
          .HasConversion(
              id => id.Value,
              value => new PhoneId(value)
          );
        modelBuilder.Entity<Category>()
          .Property(c => c.Id)
          .HasConversion(
              id => id.Value,
              value => new CategoryId(value)
          );

        modelBuilder.Entity<Product>()
         .Property(c => c.Id)
         .HasConversion(
             id => id.Value,
             value => new ProductId(value)
         );
        modelBuilder.Entity<Product>()
        .OwnsOne(p => p.Price);

        modelBuilder.Entity<Page>()
        .Property(c => c.Id)
        .HasConversion(
            id => id.Value,
            value => new PageId(value)
        );

        modelBuilder.Entity<Role>()
        .Property(c => c.Id)
        .HasConversion(
            id => id.Value,
            value => new RoleId(value)
        );


        modelBuilder.Entity<Role>()
            .HasMany(r => r.Pages)
            .WithMany(p => p.Roles)
            .UsingEntity(j => j.ToTable("RolePage"));

        modelBuilder.Entity<User>()
        .Property(c => c.Id)
        .HasConversion(
            id => id.Value,
            value => new UserId(value)
        );
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<User> Users { get; set; }
}
