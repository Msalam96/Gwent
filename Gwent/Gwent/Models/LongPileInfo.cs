using System.Collections.Generic;

namespace Gwent.Models
{
    public class LongPileInfo
    {
        public int Remaining { get; set; }
        public List<ShortCardInfo> CardInfo { get; set; }
    }
}