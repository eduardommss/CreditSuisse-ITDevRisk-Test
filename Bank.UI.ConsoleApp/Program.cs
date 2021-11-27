using Bank.Domain.Interfaces.Services;
using Bank.IoC;
using Bank.UI.ConsoleApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Bank.UI.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            using IServiceScope serviceScope = host.Services.CreateScope();

            IServiceProvider provider = serviceScope.ServiceProvider;

            ITradeService tradeService = provider.GetRequiredService<ITradeService>();
            ICategoryService categoryService = provider.GetRequiredService<ICategoryService>();

            new TradeView(tradeService, categoryService);
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.RegisterRepositoriesAndServices();
                }
                );
    }
}
