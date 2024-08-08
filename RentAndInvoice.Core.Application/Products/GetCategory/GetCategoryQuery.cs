using MediatR;
using RentAndInvoice.Core.Domain.Entities.Products;

namespace RentAndInvoice.Core.Application.Products.GetCategory;

public record GetCategoryQuery(CategoryId CategoryId) : IRequest<CategoryResponse>;

public record CategoryResponse(
    Guid Id,
    string Name
    );
