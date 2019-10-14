using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSharedLibrary.Models
{
    class PileCard
    {

        public int Id { get; set; }

        public int PileId { get; set; }
        public Pile Pile { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

        public Location Location { get; set; }
    }
}
