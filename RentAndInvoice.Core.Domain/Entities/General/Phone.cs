namespace RentAndInvoice.Core.Domain.Entities.General;

public class Phone
{
    public Phone(PhoneId id, string number)
    {
        Id = id;
        Number = number;
    }

    private Phone()
	{

	}

	public PhoneId Id { get; set; }

	public string Number { get; set; }


    public void Update(string number)
    {
        Number = number;
    }
}
