using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSharedLibrary.Models
{
    public class DeckUser
    {
        public int Id { get; set; }

        public int DeckId { get; set; }
        public Deck Deck { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
