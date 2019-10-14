using GwentSharedLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GwentSharedLibrary.Repositories
{
    public interface IDeckRepository
    {
        Task<Deck> CreateNewShuffledDeckAsync();
        Task<Deck> GetDeck(int deckId);
        Task<List<Card>> GetCards(int deckId, int numberofCards);
        Task<Pile> GetPile(int deckId, string pileName);
        Task<Pile> AddToPile(int deckId, string pileName, int numberofCards);
    }
}