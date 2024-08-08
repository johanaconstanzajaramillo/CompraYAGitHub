using MediatR;
using RentAndInvoice.Core.Application.Data;
using RentAndInvoice.Core.Domain.Entities.Customers;

namespace RentAndInvoice.Core.Application.Customers.GetCustomer;

internal sealed class GetCategoryQueryHandler : IRequestHandler<GetCustomerQuery, CustomerResponse>
{
    private readonly IApplicationDbContext _context;

    public GetCategoryQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }


    public Task<CustomerResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = _context
           .Customers
           .Where(c => c.Id == request.CustomerId)
           .Select(c => new CustomerResponse(
               c.Id.Value,
               c.Name,
               c.Email))
           .FirstOrDefault();

        if (customer is null)
        {
            throw new CustomerNotFoundException(request.CustomerId);
        }

        return Task.FromResult(customer);
    }
}
