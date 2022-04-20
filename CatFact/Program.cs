using CatFact.Helpers;
using CatFact.Logic;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CatFact
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection(); 
            ConfigureServices(services);
            await services
                .BuildServiceProvider()
                .GetService<CatFactService>()
                .GetAndSaveCatFact();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddHttpClient()
                .AddSingleton<CatFactService, CatFactService>()                                                         
                .AddSingleton<FileWriter, FileWriter>();
        }
    }
}
