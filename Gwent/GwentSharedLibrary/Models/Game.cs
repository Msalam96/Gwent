using System.Collections.Generic;

namespace GwentSharedLibrary.Models
{
    public class Game
    {
        public Game()
        {
            Piles = new List<Pile>();
            Messages = new List<GameMessage>();
        }

        public Game(int playerOneId, int playerTwoId)
        {
            PlayerOneId = playerOneId;
            PlayerTwoId = playerTwoId; 
        }

        public int Id { get; set; }

        public int PlayerOneId { get; set; }
        public User PlayerOne { get; set; }

        public int PlayerTwoId { get; set; }
        public User PlayerTwo { get; set; }

        public List<Pile> Piles { get; set; }
        public List<GameMessage> Messages { get; set; }
    }
}
