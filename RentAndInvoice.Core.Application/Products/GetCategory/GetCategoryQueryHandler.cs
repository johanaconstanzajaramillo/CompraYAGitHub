using MediatR;
using RentAndInvoice.Core.Application.Data;
using RentAndInvoice.Core.Domain.Entities.Products;

namespace RentAndInvoice.Core.Application.Products.GetCategory;

internal sealed class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryResponse>
{
    private readonly IApplicationDbContext _context;

    public GetCategoryQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }


    public Task<CategoryResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = _context
           .Categories
           .Where(c => c.Id == request.CategoryId)
           .Select(c => new CategoryResponse(
               c.Id.Value,
               c.Name))
           .FirstOrDefault();

        if (category is null)
        {
            throw new CategoryNotFoundException(request.CategoryId);
        }

        return Task.FromResult(category);
    }
}
