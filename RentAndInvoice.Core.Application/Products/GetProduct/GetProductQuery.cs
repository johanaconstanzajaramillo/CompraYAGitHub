using MediatR;
using RentAndInvoice.Core.Application.Products.GetCategory;
using RentAndInvoice.Core.Domain.Entities.Products;

namespace RentAndInvoice.Core.Application.Products.GetProduct;

public record GetProductQuery(ProductId ProductId) : IRequest<ProductResponse>;

public record ProductResponse(
    Guid Id,
    string Name,
    string Currency,
    decimal Ammount,
    int AmmountStock,
    CategoryResponse CategoryResponse
    );
