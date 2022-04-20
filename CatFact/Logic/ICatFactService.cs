using System.Threading.Tasks;

namespace CatFact.Logic
{
    public interface ICatFactService
    {
        Task GetAndSaveCatFact();
    }
}