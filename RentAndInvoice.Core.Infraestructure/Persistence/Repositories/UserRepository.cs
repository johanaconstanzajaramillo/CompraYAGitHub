
using RentAndInvoice.Core.Domain.Entities.Security;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Infraestructure.Persistence.Repositories;

internal sealed class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public User GetByIdAsync(UserId id)
    {
        return _context.Users
            .FirstOrDefault(p => p.Id == id);
    }

    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User GetByCredendialsAsync(string email, string password)
    {
        User user = _context.Users
                    .Where(u => u.Email.ToUpper() == email.ToUpper() && u.Password.ToUpper() == password.ToUpper())
                    .FirstOrDefault();
        ;

        return user;
    }
}
