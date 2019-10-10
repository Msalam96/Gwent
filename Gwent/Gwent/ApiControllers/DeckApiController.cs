using Gwent.Models;
using Gwent.Repositories;
using System.Collections.Generic;
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

            List<ShortCardInfo> cardInfos = new List<ShortCardInfo>();

            foreach (var card in deck.Cards)
            {
                var shortCardInfo = new ShortCardInfo
                {
                    Name = card.Name,
                    Description = card.Description,
                    Strength = card.Strength.Value,
                    CardType = card.CardType,
                    SpecialAbility = card.SpecialAbility
                };
                cardInfos.Add(shortCardInfo);
            }

            ShortDeckInfo deckInfo = new ShortDeckInfo
            {
                DeckId = deck.Id,
                Faction = deck.Faction,
                Remaining = deck.Cards.Where(d => !d.Drawn).Count(),
                Cards = cardInfos
            };

            return deckInfo;
        }
    }
}