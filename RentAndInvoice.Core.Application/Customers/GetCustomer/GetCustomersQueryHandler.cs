using MediatR;
using RentAndInvoice.Core.Application.Data;

namespace RentAndInvoice.Core.Application.Customers.GetCustomer;

internal sealed class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetCustomersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }


    public Task<List<CustomerResponse>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = _context
           .Customers
           .Select(p => new CustomerResponse(
               p.Id.Value,
               p.Name,
               p.Email)).ToList();

        return Task.FromResult(customers);
    }
}
