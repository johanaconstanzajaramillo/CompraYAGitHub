namespace RentAndInvoice.Core.Domain.Entities.Customers
{
    public enum CustomerStatus
    {
        Undefined = 0,
        Owes =1, // Customer has outstanding payments
        InGoodStanding=2 // 2nd element - Customer is in good standing
    }
}
