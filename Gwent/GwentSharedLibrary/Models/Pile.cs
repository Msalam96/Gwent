using System.ComponentModel.DataAnnotations;

namespace GwentSharedLibrary.Models
{
    public class Pile
    {
        public Pile()
        {
        }

        public Pile(int id, int deckId, Deck deck) : this()
        {
            Id = id;
            DeckId = deckId;
            Deck = deck;
        }

        public int Id { get; set; }

        [Required]
        public int DeckId { get; set; }
        public Deck Deck { get; set; }
        
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}