using System.ComponentModel.DataAnnotations;

namespace GwentSharedLibrary.Models
{
    public class Card
    {
        public Card() { }

        public Card(int id, string name, string description, int? strength, 
            CardType cardType, SpecialAbility? specialAbility, string imageUrl)
        {
            Id = id;
            Name = name;
            Description = description;
            Strength = strength;
            CardType = cardType;
            SpecialAbility = specialAbility;
            ImageUrl = imageUrl;
        }

        public int Id { get; set; }
        
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

    }
}