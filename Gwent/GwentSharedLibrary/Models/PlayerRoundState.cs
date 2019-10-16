namespace GwentSharedLibrary.Models
{
    public class PlayerRoundState
    {
        public int Score {
            get
            {
                return CloseCombat.Score + Ranged.Score + Siege.Score;
            }
        }
        public CardTypeState CloseCombat { get; set; }
        public CardTypeState Ranged { get; set; }
        public CardTypeState Siege { get; set; }
    }
}