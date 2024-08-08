namespace RentAndInvoice.Core.Domain.Entities.Security;

public class Role
{
    public Role(RoleId id, string name, byte priority, List<Page> pages)
    {
        Id = id;
        Name = name;
        Priority = priority;
        Pages = pages;
    }

    public RoleId Id { get; set; }

    public string Name { get; set; }

    public byte Priority { get; set; }

    public List<Page> Pages { get; set; }

    public void Update(string name, byte priority, List<Page> pages)
    {
        Name = name;
        Priority = priority;
        Pages = pages;
    }
    private Role()
    {

    }
}
