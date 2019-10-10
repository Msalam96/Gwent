using Gwent.Models;
using System.Threading.Tasks;

namespace Gwent.Repositories
{
    public interface IDeckRepository
    {
        Task<Deck> CreateNewShuffledDeckAsync();
    }
}