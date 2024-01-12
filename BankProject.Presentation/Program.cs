using BankProject.Configuration;
using BankProject.Presentation;
using BankProject.Repositories;
using BankProject.RepositoryContracts;
using BankProject.ServiceContracts;
using BankProject.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // Add your services here using dependency injection
                    services.AddTransient<ICustomersRepository,CustomersRepository>();
                    services.AddTransient<ICustomersService,CustomersService>();

                    MainMenuDisplay.DisplayMenu();
                });
}