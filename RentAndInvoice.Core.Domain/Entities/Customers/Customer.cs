using RentAndInvoice.Core.Domain.Entities.General;

namespace RentAndInvoice.Core.Domain.Entities.Customers;

public class Customer
{
   

    private Customer()
	{

	}

    public Customer(CustomerId id, DocumentType documentType, string documentNumber, string name, string email, List<Phone> phones, List<Address> addresses, CustomerType customerType)
    {
        Id = id;
        DocumentType = documentType;
        DocumentNumber = documentNumber;
        Name = name;
        Email = email;
        Phones = phones;
        Addresses = addresses;
        CustomerType = customerType;
    }

    public void Update(DocumentType documentType, string documentNumber, string name, string email, List<Phone> phones, List<Address> addresses, CustomerType customerType)
    {
        DocumentType = documentType;
        DocumentNumber = documentNumber;
        Name = name;
        Email = email;
        Phones = phones;
        Addresses = addresses;
        CustomerType = customerType;
    }

    public CustomerId Id { get; set; }

	public DocumentType DocumentType { get; set; }

	public string DocumentNumber { get; set; }

    public string Name { get; set; }

	public string Email { get; set; }

	public List<Phone> Phones { get; set; }

    public List<Address> Addresses { get; set; }

    public CustomerType CustomerType { get; set; }
}
