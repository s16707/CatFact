using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFact.Helpers
{
    public class FileWriter
    {
        public FileWriter()
        {

        }
        public async Task WriteToFile(string content) {
            using StreamWriter file = new("WriteLines2.txt", append: true);
            await file.WriteLineAsync(content);
        }
    }
}
