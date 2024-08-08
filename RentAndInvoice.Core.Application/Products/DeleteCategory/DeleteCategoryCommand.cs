using MediatR;
using RentAndInvoice.Core.Domain.Entities.Products;

namespace RentAndInvoice.Core.Application.Products.DeleteCategory;

public record DeleteCategoryCommand(CategoryId CategoryId) : IRequest;