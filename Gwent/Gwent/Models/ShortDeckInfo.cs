using System.Collections.Generic;

namespace Gwent.Models
{
    public class ShortDeckInfo
    {
        public int DeckId { get; set; }
        public int Remaining { get; set; }
        public string Faction { get; set; }
        public List<ShortCardInfo> Cards { get; set; }
    }
}