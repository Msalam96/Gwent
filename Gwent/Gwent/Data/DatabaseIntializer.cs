using Gwent.Models;
using System.Data.Entity;
using System.Web;

namespace Gwent.Data
{
    public class DatabaseIntializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            Deck deck = new Deck(0);

            Card footSolider = new Card(0, false, "Redanian Foot Soldier", "I've bled for Redania! I've killed for Redania... Dammit, I've even raped for Redania!", 1, CardType.CloseCombat, null);

            footSolider.Deck = deck;
            footSolider.DeckId = deck.Id;

            deck.Cards.Add(footSolider);

            context.Cards.Add(footSolider);
            context.Decks.Add(deck);
            context.SaveChanges();
        }
    }
}