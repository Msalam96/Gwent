namespace GwentSharedLibrary.Models
{
    public class RoundState
    {
        public int GameRoundId { get; set; }
        public PlayerRoundState Player1RoundState { get; set; }
        public PlayerRoundState Player2RoundState { get; set; }
        public int ActivePlayerId { get; set; }
    }
}