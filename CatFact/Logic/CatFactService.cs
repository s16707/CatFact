using CatFact.Helpers;
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
            var response = await _httpClient.GetAsync("https://catfact.ninja/fact");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            await _fileWriter.WriteToFile(responseBody);
        }
    }
}
