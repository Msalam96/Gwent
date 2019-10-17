using System.Collections.Generic;
using System.Linq;

namespace GwentSharedLibrary.Models
{
    public class CardTypeState
    {
        public int Score {
            get
            {
                return Cards.Sum(bc => bc.getScore());
                //int sum = 0;
                //foreach (var boardCard in BoardCardState)
                //{
                //    sum += boardCard.getScore();
                //}
                //return sum;
            }
        }

        public List<BoardCardState> Cards { get; set; }
    }
}