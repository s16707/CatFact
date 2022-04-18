using CatFact.Helpers;
using CatFact.Logic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CatFact
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection(); //obiekt zawiera serwisy
            ConfigureServices(services);
            await services
                .AddSingleton<GetFactLogic, GetFactLogic>()
                .BuildServiceProvider()
                .GetService<GetFactLogic>()
                .Execute();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<HttpClient, HttpClient>()
                .AddSingleton<FileWriter, FileWriter>();
        }
    }
}
