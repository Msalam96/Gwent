using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GwentSharedLibrary.Models
{
    public class Pile
    {
        public Pile()
        {
            PileCards = new List<PileCard>();
        }

        public int Id { get; set; }

        public int DeckId { get; set; }
        public Deck Deck { get; set; }
        
        public int GameId { get; set; }
        public Game Game { get; set; }

        public List<PileCard> PileCards { get; set; }
    }
}