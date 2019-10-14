using GwentSharedLibrary.Models;

namespace Gwent.Models
{
    public class ShortCardInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Strength { get; set; }
        public CardType CardType { get; set; }
        public SpecialAbility? SpecialAbility { get; set; }
        public string Image { get; set; }
    }
}