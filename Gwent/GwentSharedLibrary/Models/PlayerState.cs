using System.Collections.Generic;

namespace GwentSharedLibrary.Models
{
    public class PlayerState
    {
        public string FirstName { get; set; }
        public int PlayerId { get; set; }
        public int RoundsWon { get; set; }
        
        public List<PlayerHandState> Hand { get; set; }
    }
}
