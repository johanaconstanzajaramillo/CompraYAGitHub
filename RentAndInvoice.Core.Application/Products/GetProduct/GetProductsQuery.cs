using MediatR;

namespace RentAndInvoice.Core.Application.Products.GetProduct;

public sealed record GetProductsQuery : IRequest<List<ProductResponse>>;