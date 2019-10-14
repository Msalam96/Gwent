using System.ComponentModel.DataAnnotations;

namespace GwentSharedLibrary.Models
{
    public class Card
    {
        public Card() { }

        public Card(string name, int? strength, 
            CardType cardType, SpecialAbility? specialAbility, string imageUrl)
        {
            Name = name;
            Strength = strength;
            CardType = cardType;
            SpecialAbility = specialAbility;
            ImageUrl = imageUrl;
        }

        public int Id { get; set; }
        
        public int Order { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Strength { get; set; }

        [Required]
        public CardType CardType { get; set; }

        public SpecialAbility? SpecialAbility { get; set; }

        [Required]
        public string ImageUrl { get; set; }

    }
}