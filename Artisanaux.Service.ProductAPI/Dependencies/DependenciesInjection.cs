using Artisanaux.Service.ProductAPI.Repository;

namespace Artisanaux.Service.ProductAPI.Dependencies
{
    public static class DependenciesInjection
    {
        internal static void AddScopedServices(this IServiceCollection services)
        {
            //Service injection
            services.AddScoped<IProductRepository, ProductRepository>();
        }

    }
}
