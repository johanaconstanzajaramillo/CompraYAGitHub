using MediatR;
using RentAndInvoice.Core.Domain.Entities.Products;
using RentAndInvoice.Core.Domain.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace RentAndInvoice.Core.Application.Products.CreateProduct;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    public CreateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
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


        var product = new Product(
            new ProductId(Guid.NewGuid()),
            request.Name,
            new Money(request.Currency, request.Ammount),
            request.AmmountStock,
            category,
            request.Enabled);

        _productRepository.Add(product);
        return Task.CompletedTask;
    }
}
