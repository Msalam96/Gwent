using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSharedLibrary.Models
{
    class Game
    {
        public int Id { get; set; }

        public int PlayerOneId { get; set; }
        public User PlayerOne { get; set; }

        public int PlayerTwoId { get; set; }
        public User PlayerTwo { get; set; }

    }
}
