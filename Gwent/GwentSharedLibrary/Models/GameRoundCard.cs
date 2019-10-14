using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSharedLibrary.Models
{
    class GameRoundCard
    {
        public int Id { get; set; }

        public int GameRoundId { get; set; }
        public GameRound GameRound { get; set; }

        public int PileCardId { get; set; }
        public PileCard PileCard { get; set; }
    }
}
