namespace GwentSharedLibrary.Models
{
    public class DeckCard
    {
        public DeckCard () { }
        
        public int Id { get; set; }
        public int DeckId { get; set; }
        public int CardId { get; set; }

        public Card Card { get; set; }
        public Deck Deck { get; set; }
    }
}
