namespace RentAndInvoice.Core.Domain.Entities.Customers;

public sealed class CustomerNotFoundException : Exception
{

	public CustomerNotFoundException(CustomerId id): base($"The customer with the ID = {id.Value} was not found")
	{

	}
}
