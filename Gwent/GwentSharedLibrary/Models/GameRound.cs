namespace GwentSharedLibrary.Models
{
    public class GameRound
    {
        public GameRound() { }

        public GameRound(int id, int gameId, int firstPlayerId, int secondPlayerId)
        {
            Id = id;
            GameId = gameId;
            FirstPlayerId = firstPlayerId;
            SecondPlayerId = secondPlayerId;
        }

        public int Id { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int FirstPlayerId { get; set; }
        public User FirstPlayer { get; set; }

        public int SecondPlayerId { get; set; }
        public User SecondPlayer { get; set; }

        public bool FirstPlayerPassed { get; set; }
        public bool SecondPlayerPassed { get; set; }

        public int? WinnerPlayerId { get; set; }
        public User WinnerPlayer { get; set; }
    }
}
