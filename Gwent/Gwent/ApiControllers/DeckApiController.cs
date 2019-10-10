using Gwent.Models;
using Gwent.Repositories;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Gwent.ApiControllers
{
    [RoutePrefix("api/deck")]
    public class DeckApiController : ApiController
    {
        private IDeckRepository _repository;

        public DeckApiController() { }

        public DeckApiController(IDeckRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        async public Task<ShortDeckInfo> Post()
        {
            Deck deck = await _repository.CreateNewShuffledDeckAsync();
            ShortDeckInfo deckInfo = new ShortDeckInfo
            {
                DeckId = deck.Id,
                Remaining = deck.Cards.Where(d => !d.Drawn).Count()
            };

            return deckInfo;
        }
    }
}