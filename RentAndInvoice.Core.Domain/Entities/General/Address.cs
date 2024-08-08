namespace RentAndInvoice.Core.Domain.Entities.General;

public class Address
{
    public Address(string descripcion, AddressId id)
    {
        Descripcion = descripcion;
        Id = id;
    }

    private Address()
	{

	}

	public string Descripcion { get; set; }

	public AddressId Id { get; set; }

    public void Update(string descripcion)
    {
        Descripcion = descripcion;
    }
}
