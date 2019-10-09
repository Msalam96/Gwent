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

        public Deck(int id) : this()
        {
            Id = id;
        }

        public int Id { get; set; }

        //[Required]
        //public string Faction { get; set; }

        public IList<Card> Cards { get; set; }
    }
}