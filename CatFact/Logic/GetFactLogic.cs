using CatFact.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CatFact.Logic
{
    public class GetFactLogic
    {
        private readonly HttpClient _httpClient;
        private readonly FileWriter _fileWriter;
        public GetFactLogic(HttpClient httpClient, FileWriter fileWriter)
        {
            _httpClient = httpClient;
            _fileWriter = fileWriter;
        }
        public async Task Execute()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://catfact.ninja/fact");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            await _fileWriter.WriteToFile(responseBody);
        }
    }
}
