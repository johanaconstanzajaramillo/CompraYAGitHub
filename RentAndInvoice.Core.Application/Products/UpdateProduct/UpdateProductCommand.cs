using MediatR;
using RentAndInvoice.Core.Domain.Entities.Products;

namespace RentAndInvoice.Core.Application.Products.UpdateProduct;

public record UpdateProductCommand(
    ProductId ProductId,
    string Name,
        string Currency,
        decimal Ammount,
        int AmmountStock,
        Guid CategoryId,
        bool Enabled
    ) : IRequest;

public record UpdateProductRequest(
    string Name,
        string Currency,
        decimal Ammount,
        int AmmountStock,
        Guid CategoryId,
        bool Enabled
    ) : IRequest;