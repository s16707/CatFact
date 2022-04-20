using System;
using System.IO;
using System.Threading.Tasks;

namespace CatFact.Helpers
{
    public class FileWriter : IFileWriter
    {
        public FileWriter()
        {

        }
        public async Task WriteToFile(string content) {
            try
            {
                using StreamWriter file = new("WriteLines2.txt", append: true);
                await file.WriteLineAsync(content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
