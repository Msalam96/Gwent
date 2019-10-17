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

        public PlayerState Player1 { get; set; }
        public PlayerState Player2 { get; set; }

        public RoundState Round { get; set; }

        public Winner Winner {
            get {
                if (Player1.RoundsWon == 2)
                {
                    return new Winner()
                    {
                        PlayerId = Player1.PlayerId,
                        PlayerName = Player1.FirstName
                    };
                }
                else if (Player2.RoundsWon == 2)
                {
                    return new Winner()
                    {
                        PlayerId = Player2.PlayerId,
                        PlayerName = Player2.FirstName
                    };
                }
                else { return null; }
            } }
        //Make class PlayerState
        //One for PlayerOne
        //One for PlayerTwo


        //Make class RoundState

    }
}
