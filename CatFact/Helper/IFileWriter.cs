using System.Threading.Tasks;

namespace CatFact.Helpers
{
    public interface IFileWriter
    {
        Task WriteToFile(string content);
    }
}