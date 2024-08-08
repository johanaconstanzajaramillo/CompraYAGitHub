using MediatR;
using RentAndInvoice.Core.Domain.Entities.Products;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Application.Products.DeleteProduct;

internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository _productRepository;
    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = _productRepository.GetByIdAsync(request.ProductId);

        if (product is null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }

        _productRepository.Remove(product);

        return Task.CompletedTask;
    }
}
