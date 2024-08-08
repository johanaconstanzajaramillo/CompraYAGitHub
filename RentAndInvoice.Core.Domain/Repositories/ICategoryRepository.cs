using RentAndInvoice.Core.Domain.Entities.Products;

namespace RentAndInvoice.Core.Domain.Repositories;

public interface ICategoryRepository
{
    Category GetByIdAsync(CategoryId id);

    void Add(Category category);

    void Update(Category category);

    void Remove(Category category);
}
