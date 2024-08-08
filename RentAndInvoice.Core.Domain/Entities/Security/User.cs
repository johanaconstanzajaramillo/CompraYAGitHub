namespace RentAndInvoice.Core.Domain.Entities.Security;

public class User
{
    public UserId Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public List<Role> Roles { get; set; }

    public bool Enabled { get; set; }


    private  User()
    {

    }

    public User(UserId id, string firstName, string lastName, string password, string email, List<Role> roles, bool enabled)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Email = email;
        Roles = roles;
        Enabled = enabled;
    }

    public void Update(string firstName, string lastName, string password, string email, List<Role> roles, bool enabled)
    {
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Email = email;
        Roles = roles;
        Enabled = enabled;
    }
}
