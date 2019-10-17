using System.Collections.Generic;
using System.Linq;

namespace GwentSharedLibrary.Models
{
    public class CardTypeState
    {
        public int Score {
            get
            {
                if(!Weather)
                {
                    return BoardCardState.Sum(bc => bc.getScore());
                } else
                {
                    return 1;
                }
                //int sum = 0;
                //foreach (var boardCard in BoardCardState)
                //{
                //    sum += boardCard.getScore();
                //}
                //return sum;
            }
        }

        public List<BoardCardState> BoardCardState { get; set; }

        public bool Weather { private get; set; }
    }
}