using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GwentSharedLibrary.Models
{
    public class Deck
    {

        public Deck() {
            DeckCards = new List<DeckCard>();
            DeckUsers = new List<DeckUser>();
        }

        public Deck(int id, string faction) : this()
        {
            Id = id;
            Faction = faction;

        }

        public int Id { get; set; }

        [Required]
        public string Faction { get; set; }


        public List<DeckCard> DeckCards { get; set; }
        public List<DeckUser> DeckUsers { get; set; }


        public void AddCard (Card card)
        {
            DeckCards.Add(new DeckCard()
            {
                Card = card,
                Deck = this,
                IsDrawn = false
            });
        }
    }
}