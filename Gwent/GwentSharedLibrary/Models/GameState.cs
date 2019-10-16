using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSharedLibrary.Models
{
    public class GameState
    {
        public int GameId { get; set; }
        public int RoundNumber { get; set; }

        public Dictionary<string, PlayerState> Player1State { get; set; }
        public Dictionary<string, PlayerState> Player2State { get; set; }
        //Make class PlayerState
        //One for PlayerOne
        //One for PlayerTwo


        //Make class RoundState
        


    }
}
