namespace GwentSharedLibrary.Models
{
    public class Game
    {
        public Game() { }


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
    }
}
