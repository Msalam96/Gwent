using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gwent.Models
{
    public class ShortCardInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Strength { get; set; }
        public CardType CardType { get; set; }
        public SpecialAbility? SpecialAbility { get; set; }
    }
}