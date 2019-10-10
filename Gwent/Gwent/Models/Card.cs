using System.ComponentModel.DataAnnotations;

namespace Gwent.Models
{
    public class Card
    {
        public Card() { }

        public Card(int id, bool drawn, string name, string description, int? strength, 
            CardType cardType, SpecialAbility? specialAbility, string imageUrl)
        {
            Id = id;
            Drawn = drawn;
            Name = name;
            Description = description;
            Strength = strength;
            CardType = cardType;
            SpecialAbility = specialAbility;
            ImageUrl = imageUrl;
        }

        public int Id { get; set; }
        
        public bool Drawn { get; set; }

        public int Order { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int? Strength { get; set; }

        [Required]
        public CardType CardType { get; set; }

        public SpecialAbility? SpecialAbility { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int DeckId { get; set; }
        public Deck Deck { get; set; }

        public int? PileId { get; set; }
        public Pile Pile { get; set; }
    }
}