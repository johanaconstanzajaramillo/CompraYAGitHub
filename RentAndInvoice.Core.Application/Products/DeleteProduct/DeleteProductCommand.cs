using MediatR;
using RentAndInvoice.Core.Domain.Entities.Products;

namespace RentAndInvoice.Core.Application.Products.DeleteProduct;

public record DeleteProductCommand(ProductId ProductId) : IRequest;