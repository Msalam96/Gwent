using GwentSharedLibrary.Data;
using GwentSharedLibrary.Models;
using System;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace GwentSharedLibrary.Repositories
{
    public class DeckRepository : IDeckRepository
    {
        async public Task<Deck> CreateNewShuffledDeckAsync()
        {
            Deck deck = new Deck(0, "Northern Realms");
            var cards = new Card[22];

            cards[0] = new Card(0, false, "Redanian Foot Soldier", "I've bled for Redania! I've killed for Redania... Dammit, I've even raped for Redania!",
                1, CardType.CloseCombat, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/redanian_foot_soldier2_card.jpg");
            cards[0].Deck = deck;
            cards[0].DeckId = deck.Id;

            cards[1] = new Card(0, false, "Poor F***ing Infantry", "I's a war veteran! ... spare me a crown?",
                1, CardType.CloseCombat, SpecialAbility.Bond, "https://vignette.wikia.nocookie.net/witcher/images/1/16/Tw3_gwent_card_face_Poor_Fucking_Infantry.png/revision/latest?cb=20160320094501");
            cards[1].Deck = deck;
            cards[1].DeckId = deck.Id;

            cards[2] = new Card(0, false, "Poor F***ing Infantry", "I's a war veteran! ... spare me a crown?",
                1, CardType.CloseCombat, SpecialAbility.Bond, "https://vignette.wikia.nocookie.net/witcher/images/1/16/Tw3_gwent_card_face_Poor_Fucking_Infantry.png/revision/latest?cb=20160320094501");
            cards[2].Deck = deck;
            cards[2].DeckId = deck.Id;

            cards[3] = new Card(0, false, "Yarpen Zigrin", "The world belongs to whoever's best at crackin' skulls and impregnatin' lasses",
                2, CardType.CloseCombat, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/yarpen_zigrin_card.jpg");
            cards[3].Deck = deck;
            cards[3].DeckId = deck.Id;

            cards[4] = new Card(0, false, "Blue Stripes Commando", "I'd do anything for Temeria. Mostly, though, I kill for her.",
                4, CardType.CloseCombat, SpecialAbility.Bond, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/blue_stripes_commando_card.jpg");
            cards[4].Deck = deck;
            cards[4].DeckId = deck.Id;

            cards[5] = new Card(0, false, "Blue Stripes Commando", "I'd do anything for Temeria. Mostly, though, I kill for her.",
                4, CardType.CloseCombat, SpecialAbility.Bond, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/blue_stripes_commando_card.jpg");
            cards[5].Deck = deck;
            cards[5].DeckId = deck.Id;

            cards[6] = new Card(0, false, "Prince Stennis", "He ploughin' wears golden armor. Golden. 'Course he's an arsehole",
                5, CardType.CloseCombat, SpecialAbility.Spy, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/prince_stennis_card.jpg");
            cards[6].Deck = deck;
            cards[6].DeckId = deck.Id;

            cards[7] = new Card(0, false, "Siegfried of Denesle", "We're on the same side, witcher. You'll realize this one day",
                5, CardType.CloseCombat, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/siegfried_of_denesle_card.jpg");
            cards[7].Deck = deck;
            cards[7].DeckId = deck.Id;

            cards[8] = new Card(0, false, "Ves", "Better to live one day as a king than a whole life as a beggar",
                5, CardType.CloseCombat, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/ves_card.jpg");
            cards[8].Deck = deck;
            cards[8].DeckId = deck.Id;

            cards[9] = new Card(0, false, "Esterad Thyssen", "Like all Thyssen men, he was tall, powerfully build and criminally handsome.",
                10, CardType.CloseCombat, SpecialAbility.Hero, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/esterad_thyssen_card.jpg");
            cards[9].Deck = deck;
            cards[9].DeckId = deck.Id;

            cards[10] = new Card(0, false, "Sabrina Glevissig", "The daughter of the Kaedweni Wilderness.",
                4, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/sabrina_glevissig_card.jpg");
            cards[10].Deck = deck;
            cards[10].DeckId = deck.Id;

            cards[11] = new Card(0, false, "Sheldon Skaggs", "I was there, on the front lines! Right where the fightin' was the thickest!",
                4, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/sheldon_skaggs_card.jpg");
            cards[11].Deck = deck;
            cards[11].DeckId = deck.Id;

            cards[12] = new Card(0, false, "Keira Metz", "If I am to die today, I wish to look smashing for the occasion.",
                5, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/keira_metz_card.jpg");
            cards[12].Deck = deck;
            cards[12].DeckId = deck.Id;

            cards[13] = new Card(0, false, "Sile de Tansarville", "The Lodge lacks humility. Our lust for power may yet be our undoing.",
                5, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/sile_de_tansarville_card.jpg");
            cards[13].Deck = deck;
            cards[13].DeckId = deck.Id;

            cards[14] = new Card(0, false, "Dethmold", "I once made a prisoner vomit his own entrails... Ah, good times...",
                6, CardType.Ranged, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/dethmold_card.jpg");
            cards[14].Deck = deck;
            cards[14].DeckId = deck.Id;

            cards[15] = new Card(0, false, "Kaedweni Siege Expert", "You gotta recalibrate the arm by five degrees. Do what by the what now?",
                1, CardType.Seige, SpecialAbility.Morale, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/kaedweni_siege_expert3_card.jpg");
            cards[15].Deck = deck;
            cards[15].DeckId = deck.Id;

            cards[16] = new Card(0, false, "Kaedweni Siege Expert", "You gotta recalibrate the arm by five degrees. Do what by the what now?",
                1, CardType.Seige, SpecialAbility.Morale, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/kaedweni_siege_expert3_card.jpg");
            cards[16].Deck = deck;
            cards[16].DeckId = deck.Id;

            cards[17] = new Card(0, false, "Kaedweni Siege Expert", "You gotta recalibrate the arm by five degrees. Do what by the what now?",
                1, CardType.Seige, SpecialAbility.Morale, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/kaedweni_siege_expert3_card.jpg");
            cards[17].Deck = deck;
            cards[17].DeckId = deck.Id;

            cards[18] = new Card(0, false, "Dun Banner Medic", "Stitch red to red, white to white, and everything will be all right.",
                5, CardType.Seige, SpecialAbility.Medic, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/dun_banner_medic_card.jpg");
            cards[18].Deck = deck;
            cards[18].DeckId = deck.Id;

            cards[19] = new Card(0, false, "Ballista", "Usually we give 'em female names",
                6, CardType.Seige, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/ballista2_card.jpg");
            cards[19].Deck = deck;
            cards[19].DeckId = deck.Id;

            cards[20] = new Card(0, false, "Trebuchet", "Castle won't batter itself down, now will it? Get them trebuchets rollin'!",
                6, CardType.Seige, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/trebuchet2_card.jpg");
            cards[20].Deck = deck;
            cards[20].DeckId = deck.Id;

            cards[21] = new Card(0, false, "Trebuchet", "Castle won't batter itself down, now will it? Get them trebuchets rollin'!",
                6, CardType.Seige, null, "https://thewitcher3.wiki.fextralife.com/file/The-Witcher-3/trebuchet2_card.jpg");
            cards[21].Deck = deck;
            cards[21].DeckId = deck.Id;

            Random random = new Random();

            //Fisher-Yates Shuffle
            for(int cardIndex = cards.Length -1; cardIndex >= 0; cardIndex--)
            {
                int swapIndex = random.Next(0, cardIndex);
                Card card = cards[swapIndex];
                cards[swapIndex] = cards[cardIndex];
                cards[cardIndex] = card;
                cards[cardIndex].Order = cardIndex;
                cards[swapIndex].Order = swapIndex;
            }

            foreach(Card card in cards)
            {
                deck.Cards.Add(card);
            }

            using (var context = new Context())
            {
                context.Decks.Add(deck);
                await context.SaveChangesAsync();
            }

            return deck;
          }

        async public Task<Deck> GetDeck(int deckId)
        {
            using(var context = new Context())
            {
                return await context.Decks
                .Include(d => d.Cards)
                .Include(d => d.Piles)
                .SingleAsync(d => d.Id == deckId);
            }
        }

        async public Task<Pile> GetPile(int deckId, string pileName)
        {
            using(var context = new Context())
            {
                Deck deck = await GetDeck(deckId);
                context.Decks.Attach(deck);
                Pile pile = deck.Piles.FirstOrDefault(p => p.Name == pileName);

                if (pile == null)
                {
                    pile = new Pile(0, pileName, deck.Id, deck);
                    context.Piles.Add(pile);
                    await context.SaveChangesAsync();
                }

                return pile;
            }
        }

        async public Task<List<Card>> GetCards(int deckId, int numberofCards)
        {
            using(var context = new Context())
            {
                Deck deck = await GetDeck(deckId);

                return deck.Cards.Take(numberofCards).ToList();
            }
        }

        async public Task<Pile> AddToPile(int deckId, string pileName, int numberOfCards)
        {
            using(var context = new Context())
            {
                Pile pile = await context.Piles
                    .FirstOrDefaultAsync(p => p.Name == pileName && p.DeckId == deckId);

                List<Card> cards = await context.Cards.Where(c => c.DeckId == deckId).Take(numberOfCards).ToListAsync();

                foreach (var card in cards)
                {
                    card.Pile = pile;
                    card.Drawn = true;
                    pile.Cards.Add(card);
                }

                await context.SaveChangesAsync();
                return pile;
            }
        }
    }
}