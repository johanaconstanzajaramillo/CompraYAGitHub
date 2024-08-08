using MediatR;
using RentAndInvoice.Core.Application.Data;

namespace RentAndInvoice.Core.Application.Products.GetCategory;

internal sealed class GetCustomersQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetCustomersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }


    public Task<List<CategoryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = _context
           .Categories
           .Select(c => new CategoryResponse(
               c.Id.Value,
               c.Name)).ToList();

        return Task.FromResult(categories);
    }
}
