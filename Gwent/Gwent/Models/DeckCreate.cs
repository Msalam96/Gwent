namespace Gwent.Models
{
    public class DeckCreate
    {
        public DeckCreate()
        {
            Count = 1;
        }

        public int? Count { get; set; }
    }
}