using RentAndInvoice.Core.Domain.Entities.Products;

namespace RentAndInvoice.Core.Domain.Repositories;

public interface IProductRepository
{
    Product GetByIdAsync(ProductId id);

    void Add(Product product);

    void Update(Product product);

    void Remove(Product product);
}
