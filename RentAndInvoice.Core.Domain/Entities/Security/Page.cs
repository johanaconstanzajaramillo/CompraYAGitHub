namespace RentAndInvoice.Core.Domain.Entities.Security;

public class Page
{
    public PageId Id { get; set; }

    public string Name { get; set; }

    public string Url { get; set; }

    public bool Enabled { get; set; }

    public List<Role> Roles { get; set; }


    public Page(PageId id, string name, string url, bool enabled, List<Role> roles)
    {
        Id = id;
        Name = name;
        Url = url;
        Enabled = enabled;
        Roles = roles;
    }

    public void Update(bool enabled)
    {
        Enabled = enabled;
    }

    private Page()
    {

    }
}
