using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSharedLibrary.Models
{
    public class GameState
    {
        public GameState()
        {
            Messages = new List<string>();
        }

        public int GameId { get; set; }
        public int RoundNumber { get; set; }

        public PlayerState Player1State { get; set; }
        public PlayerState Player2State { get; set; }

        public RoundState RoundState { get; set; }

        public Winner Winner {
            get {
                if (Player1State.RoundsWon == 2)
                {
                    return new Winner()
                    {
                        PlayerId = Player1State.PlayerId,
                        PlayerName = Player1State.FirstName
                    };
                }
                else if (Player2State.RoundsWon == 2)
                {
                    return new Winner()
                    {
                        PlayerId = Player2State.PlayerId,
                        PlayerName = Player2State.FirstName
                    };
                }
                else { return null; }
            }
        }

        public List<string> Messages { get; set; }
    }
}
