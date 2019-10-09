using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}