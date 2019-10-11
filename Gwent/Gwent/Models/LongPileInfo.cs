using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gwent.Models
{
    public class LongPileInfo
    {
        public int Remaining { get; set; }
        public List<ShortCardInfo> CardInfo { get; set; }
    }
}