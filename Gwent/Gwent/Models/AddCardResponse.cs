using System.Collections.Generic;

namespace Gwent.Models
{
    public class AddCardResponse
    {
        public string DeckFaction { get; set; }
        public int Remaining { get; set; }
        public Dictionary<string, ShortPileInfo> Piles { get; set; }
    }
}