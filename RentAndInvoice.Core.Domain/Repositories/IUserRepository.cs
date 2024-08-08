using RentAndInvoice.Core.Domain.Entities.Security;

namespace RentAndInvoice.Core.Domain.Repositories;

public interface IUserRepository
{
    User GetByIdAsync(UserId id);

    User GetByCredendialsAsync(string email, string password);

    List<User> GetAll();

    void Add(User user);

    void Update(User user);

    void Remove(User user);
}
