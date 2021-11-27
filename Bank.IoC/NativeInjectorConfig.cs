using Bank.Domain.Interfaces.Repositories;
using Bank.Domain.Interfaces.Services;
using Bank.Domain.Services;
using Bank.Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterRepositoriesAndServices(this IServiceCollection services)
        {
            #region Repositories
            services.AddScoped<ITradeRepository, TradeRepository>();
            #endregion

            #region Services
            services.AddScoped<ITradeService, TradeService>();
            services.AddScoped<ICategoryService, CategoryService>();
            #endregion
        }
    }
}
