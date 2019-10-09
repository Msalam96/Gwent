using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gwent.Models
{
    public class Deck
    {

        public Deck()
        {
            Cards = new List<Card>();
        }

        public int Id { get; set; }

        [Required]
        public string DeckId { get; set; }

        public IList<Card> Cards { get; set; }
    }
}