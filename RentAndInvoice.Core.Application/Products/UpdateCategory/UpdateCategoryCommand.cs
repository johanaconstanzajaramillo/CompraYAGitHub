using MediatR;
using RentAndInvoice.Core.Domain.Entities.Products;

namespace RentAndInvoice.Core.Application.Products.UpdateCategory;

public record UpdateCategoryCommand
(
    CategoryId CategoryId,
    string Name,
    bool Enabled
) : IRequest;


public record UpdateCategoryRequest(
    string Name,
    bool Enabled
    ) : IRequest;