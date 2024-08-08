using MediatR;
using Microsoft.EntityFrameworkCore;
using RentAndInvoice.Core.Application.Data;
using RentAndInvoice.Core.Application.Products.GetCategory;

namespace RentAndInvoice.Core.Application.Products.GetProduct;

internal sealed class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetProductsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }


    public Task<List<ProductResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = _context.Products
       .Include(p => p.Category) 
       .Select(p => new ProductResponse(
           p.Id.Value,
           p.Name,
           p.Price.Currency,
           p.Price.Amount,
           p.AmmountStock,
           p.Category != null ?
               new CategoryResponse(
                   p.Category.Id.Value,
                   p.Category.Name)
               : null))
       .ToList();

        return Task.FromResult(products);
    }
}
