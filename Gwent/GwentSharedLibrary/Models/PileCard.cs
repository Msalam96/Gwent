namespace GwentSharedLibrary.Models
{
    public class PileCard
    {

        public int Id { get; set; }

        public int PileId { get; set; }
        public Pile Pile { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

        public Location Location { get; set; }
    }
}
