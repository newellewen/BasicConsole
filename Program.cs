using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BasicConsole.Configuration;
using BasicConsole.Service;

namespace BasicConsole
{
    class Program
    {
        private static IConfiguration Configuration; 

        static void Main(string[] args)
        {
            try
            {
                ServiceCollection serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);

                IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
                BasicConsoleService basicConsoleService = serviceProvider.GetService<BasicConsoleService>();
                basicConsoleService.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            serviceCollection.Configure<BasicConsoleOptions>(Configuration.GetSection(nameof(BasicConsoleOptions)));
            serviceCollection.AddSingleton<BasicConsoleService>();
        }
    }
}
