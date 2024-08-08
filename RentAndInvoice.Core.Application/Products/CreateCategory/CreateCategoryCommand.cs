using MediatR;

namespace RentAndInvoice.Core.Application.Products.CreateCategory;

public record CreateCategoryCommand
(
    string Name,
    bool Enabled
) : IRequest;