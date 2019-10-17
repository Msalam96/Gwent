namespace GwentSharedLibrary.Models
{
    public class RoundState
    {
        public int GameRoundId { get; set; }
        public PlayerRoundState Player { get; set; }
        public PlayerRoundState PlayerOpponent { get; set; }
        public int ActivePlayerId { get; set; }
    }
}