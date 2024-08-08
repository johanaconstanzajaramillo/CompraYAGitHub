using MediatR;

namespace RentAndInvoice.Core.Application.Products.GetCategory;

public sealed record GetCategoriesQuery : IRequest<List<CategoryResponse>>;