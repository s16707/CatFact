using CatFact.Helpers;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatFact.Logic
{
    public class CatFactService : ICatFactService
    {
        private readonly HttpClient _httpClient;
        private readonly IFileWriter _fileWriter;
        public CatFactService(HttpClient httpClient, IFileWriter fileWriter)
        {
            _httpClient = httpClient;
            _fileWriter = fileWriter;
        }
        public async Task GetAndSaveCatFact()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://catfact.ninja/fact");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                await _fileWriter.WriteToFile(responseBody);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("HTTP exception found", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception found ", ex.Message);
            }
        }
    }
}
