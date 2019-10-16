using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSharedLibrary.Models
{
    public class PlayerState
    {
        public string FirstName { get; set; }
        public int PlayerId { get; set; }
        public int RoundsWon { get; set; }
        
        //public PlayerHandState playerHand { get; set; }
        public List<PlayerHandState> PlayerHandState { get; set; }
        //Create class PlayerHandState
    }
}
