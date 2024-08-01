using EcommerceApplication.DataAccess.Repository;
using EcommerceApplication.Domain.Services;
using EcommerceApplication.Domain.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceApplication.Infrastructure.DependencyInjection
{
    public static class Injection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
