namespace GwentSharedLibrary.Models
{
    public class RoundState
    {
        public int GameRoundId { get; set; }
        public PlayerRoundState Player1 { get; set; }
        public PlayerRoundState Player2 { get; set; }
        public int ActivePlayerId { get; set; }
    }
}