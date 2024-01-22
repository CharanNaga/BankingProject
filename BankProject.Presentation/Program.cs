using BankProject.Presentation;
using BankProject.Repositories;
using BankProject.RepositoryContracts;
using BankProject.ServiceContracts;
using BankProject.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            var mainMenuDisplay = serviceProvider.GetRequiredService<MainMenuDisplay>();
            await mainMenuDisplay.RunAsync();
        }

        await host.RunAsync();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) 
        => Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // Add your services here using dependency injection
                    services.AddScoped<ICustomersRepository,CustomersRepository>();
                    services.AddTransient<ICustomersService,CustomersService>();

                    services.AddScoped<IAccountsRepository,AccountsRepository>();
                    services.AddTransient<IAccountsService,AccountsService>();

                    services.AddScoped<ITransactionsRepository, TransactionsRepository>();
                    services.AddTransient<ITransactionsService, TransactionsService>();

                    services.AddTransient<CustomersPresentation,CustomersPresentation>();
                    services.AddTransient<CustomersMenuDisplay,CustomersMenuDisplay>();

                    services.AddTransient<AccountsPresentation,AccountsPresentation>();
                    services.AddTransient<AccountsMenuDisplay,AccountsMenuDisplay>();

                    services.AddScoped<TransactionsPresentation,TransactionsPresentation>();

                    services.AddTransient<MainMenuDisplay,MainMenuDisplay>();
                });
}