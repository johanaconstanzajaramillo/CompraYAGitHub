namespace RentAndInvoice.Core.Domain.Entities.Security;

public sealed class RoleNotFoundException : Exception
{

	public RoleNotFoundException(RoleId id): base($"The role with the ID = {id.Value} was not found")
	{

	}
}
