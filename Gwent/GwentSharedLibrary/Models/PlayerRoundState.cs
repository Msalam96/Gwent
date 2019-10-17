namespace GwentSharedLibrary.Models
{
    public class PlayerRoundState
    {
        public int Score {
            get
            {
                return CloseCombat.Score + Range.Score + Siege.Score;
            }
        }
        public CardTypeState CloseCombat { get; set; }
        public CardTypeState Range { get; set; }
        public CardTypeState Siege { get; set; }
    }
}