using MediatR;
using RentAndInvoice.Core.Domain.Entities.Products;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Application.Products.UpdateProduct;

internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    public UpdateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "El request es nulo.");
        }

        Category category = _categoryRepository.GetByIdAsync(new CategoryId(request.CategoryId));

        if (category is null)
        {
            throw new CategoryNotFoundException(new CategoryId(request.CategoryId));
        }

        var product = _productRepository.GetByIdAsync(request.ProductId);

        if (product is null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }

        product.Update(
            request.Name,
            new Money(request.Currency, request.Ammount),
            request.AmmountStock,
            category,
            request.Enabled);

        _productRepository.Update(product);

        return Task.CompletedTask;
    }
}
