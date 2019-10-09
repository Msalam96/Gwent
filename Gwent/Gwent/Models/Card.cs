using System.ComponentModel.DataAnnotations;

namespace Gwent.Models
{
    public class Card
    {
        public int Id { get; set; }
        
        public bool Drawn { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        CardType CardType { get; set; }

        SpecialAbility SpecialAbility { get; set; }

        [Required]
        public int DeckId { get; set; }
        public Deck Deck { get; set; }

        public int? PileId { get; set; }
        public Pile Pile { get; set; }
    }
}