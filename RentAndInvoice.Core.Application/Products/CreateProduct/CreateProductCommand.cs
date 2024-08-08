using MediatR;

namespace RentAndInvoice.Core.Application.Products.CreateProduct;

public record CreateProductCommand
(
    string Name,
        string Currency,
        decimal Ammount,
        int AmmountStock,
        Guid CategoryId,
        bool Enabled
) : IRequest;