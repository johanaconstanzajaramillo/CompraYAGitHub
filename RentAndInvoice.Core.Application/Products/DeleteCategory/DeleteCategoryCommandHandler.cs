using MediatR;
using RentAndInvoice.Core.Domain.Entities.Products;
using RentAndInvoice.Core.Domain.Repositories;

namespace RentAndInvoice.Core.Application.Products.DeleteCategory;

internal sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _categoryRepository.GetByIdAsync(request.CategoryId);

        if (category is null)
        {
            throw new CategoryNotFoundException(request.CategoryId);
        }

        _categoryRepository.Remove(category);

        return Task.CompletedTask;
    }
}
