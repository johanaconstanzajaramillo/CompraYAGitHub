using MediatR;
using RentAndInvoice.Core.Application.Products.UpdateCategory;
using RentAndInvoice.Core.Domain.Entities.Products;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Application.Products.CreateCategory;

public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request), "El request es nulo.");
        }

        var category = _categoryRepository.GetByIdAsync(request.CategoryId);

        if (category is null)
        {
            throw new CategoryNotFoundException(request.CategoryId);
        }

        category.Update(
            request.Name,
            request.Enabled);

        _categoryRepository.Update(category);
        return Task.CompletedTask;
    }
}
