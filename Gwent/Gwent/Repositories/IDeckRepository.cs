using Gwent.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gwent.Repositories
{
    public interface IDeckRepository
    {
        Task<Deck> CreateNewShuffledDeckAsync();
        Task<Deck> GetDeck(int deckId);
        Task<Pile> AddToPile(int deckId, string pileName, List<Card> cards)
    }
}