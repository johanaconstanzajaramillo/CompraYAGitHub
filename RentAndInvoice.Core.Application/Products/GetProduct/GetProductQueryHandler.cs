using MediatR;
using Microsoft.EntityFrameworkCore;
using RentAndInvoice.Core.Application.Data;
using RentAndInvoice.Core.Application.Products.GetCategory;
using RentAndInvoice.Core.Domain.Entities.Products;

namespace RentAndInvoice.Core.Application.Products.GetProduct;

internal sealed class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductResponse>
{
    private readonly IApplicationDbContext _context;

    public GetProductQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }


    public Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = _context
           .Products
           .Include(p => p.Category)
           .Where(p => p.Id == request.ProductId)
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
           .FirstOrDefault();

        if (product is null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }

        return Task.FromResult(product);
    }
}
