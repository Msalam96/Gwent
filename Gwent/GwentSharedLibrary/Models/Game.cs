namespace GwentSharedLibrary.Models
{
    public class Game
    {
        public Game() { }

        public int Id { get; set; }

        public int PlayerOneId { get; set; }
        public User PlayerOne { get; set; }

        public int PlayerTwoId { get; set; }
        public User PlayerTwo { get; set; }
    }
}
