using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentAndInvoice.Core.Application.Abstractions;
using RentAndInvoice.Core.Application.Data;
using RentAndInvoice.Core.Domain.Repositories;
using RentAndInvoice.Core.Infraestructure.Authentication;
using RentAndInvoice.Core.Infraestructure.Persistence;
using RentAndInvoice.Core.Infraestructure.Persistence.Repositories;

namespace RentAndInvoice.Core.Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options
                .UseNpgsql(configuration.GetConnectionString("Database")));

        services.AddScoped<IApplicationDbContext>(sp =>
            sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPageRepository, PageRepository>();
        services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();

        services.AddSingleton<IJwtProvider, JwtProvider>();

        return services;
    }
}