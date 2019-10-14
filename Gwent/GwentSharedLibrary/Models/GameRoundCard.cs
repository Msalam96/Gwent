namespace GwentSharedLibrary.Models
{
    public class GameRoundCard
    {
        public int Id { get; set; }

        public int GameRoundId { get; set; }
        public GameRound GameRound { get; set; }

        public int PileCardId { get; set; }
        public PileCard PileCard { get; set; }
    }
}
