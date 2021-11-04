using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BasicConsole.Configuration;

namespace BasicConsole
{
    class Program
    {
        private static IConfiguration Configuration { get; } 

        static void Main(string[] args)
        {
            try
            {
                ServiceCollection serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
            }
            catch
            {

            }
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Configure<BasicConsoleOptions>(Configuration.GetSection(nameof(BasicConsoleOptions)));
        }
    }
}
