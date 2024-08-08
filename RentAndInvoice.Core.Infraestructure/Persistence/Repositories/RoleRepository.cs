using RentAndInvoice.Core.Domain.Entities.Security;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Infraestructure.Persistence.Repositories;

internal sealed class RoleRepository : IRoleRepository
{
    private readonly ApplicationDbContext _context;

    public RoleRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Role role)
    {
        _context.Roles.Add(role);

        _context.SaveChanges();
    }

    public void Update(Role role)
    {
        _context.Roles.Update(role);
        _context.SaveChanges();
    }

    public void Remove(Role role)
    {
        _context.Roles.Remove(role);
        _context.SaveChanges();
    }

    public Role GetByIdAsync(RoleId id)
    {
        return _context.Roles
            .FirstOrDefault(p => p.Id == id);
    }

    public List<Role> GetAll()
    {
        return _context.Roles.ToList();
    }
}
