using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gwent.Models
{
    public class Deck
    {

        public Deck()
        {
            Cards = new List<Card>();
            Piles = new List<Pile>();
        }

        public Deck(int id, string faction) : this()
        {
            Id = id;
            Faction = faction;
        }

        public int Id { get; set; }

        [Required]
        public string Faction { get; set; }

        public IList<Card> Cards { get; set; }

        public IList<Pile> Piles { get; set; }
    }
}