using Gwent.Models;
using Gwent.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Gwent.ApiControllers
{
    [EnableCors("*", "*", "*")]
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
        async public Task<ShortDeckInfo> Get()
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
                    SpecialAbility = card.SpecialAbility,
                    Image = card.ImageUrl
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

        [Route("{deckId}/piles/{pileName}/{numberofCards}")]
        async public Task<AddCardResponse> Patch(int deckId, string pileName, int numberofCards)
        {
            Deck deck = await _repository.GetDeck(deckId);
            Pile pile = await _repository.GetPile(deckId, pileName);

            List<Card> cards = await _repository.GetCards(deckId, numberofCards);

            pile = await _repository.AddToPile(deckId, pileName, numberofCards);
            deck = await _repository.GetDeck(deckId);

            var pileInfo = new Dictionary<string, ShortPileInfo>();

            foreach(var _pile in deck.Piles)
            {
                var info = new ShortPileInfo();
                info.Remaining = _pile.Cards.Count;
                pileInfo.Add(pileName, info);
            }

            return new AddCardResponse
            {
                DeckFaction = deck.Faction,
                Remaining = deck.Cards.Where(x => !x.Drawn).Count(),
                Piles = pileInfo
            };
        }

        [Route("{deckId}/piles/{pileName}/list")]
        async public Task<LongPileInfo> Get(int deckId, string pileName)
        {
            Deck deck = await _repository.GetDeck(deckId);
            Pile pile = await _repository.GetPile(deckId, pileName);

            List<Card> cards = pile.Cards.ToList();
            var cardInfo = new List<ShortCardInfo>();

            foreach (var card in cards)
            {
                var info = new ShortCardInfo();
                info.Name = card.Name;
                info.Description = card.Description;
                info.Strength = card.Strength;
                info.CardType = card.CardType;
                info.SpecialAbility = card.SpecialAbility;
                info.Image = card.ImageUrl;
                cardInfo.Add(info);
            }

            return new LongPileInfo
            {
                Remaining = pile.Cards.Count,
                CardInfo = cardInfo
            };
        }
    }
}