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

        public PlayerState Player { get; set; }
        public PlayerState PlayerOpponent { get; set; }

        public RoundState Round { get; set; }

        public Winner Winner {
            get {
                if (Player.RoundsWon == 2)
                {
                    return new Winner()
                    {
                        PlayerId = Player.PlayerId,
                        PlayerName = Player.FirstName
                    };
                }
                else if (PlayerOpponent.RoundsWon == 2)
                {
                    return new Winner()
                    {
                        PlayerId = PlayerOpponent.PlayerId,
                        PlayerName = PlayerOpponent.FirstName
                    };
                }
                else { return null; }
            }
        }

        public List<string> Messages { get; set; }
    }
}
