using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSharedLibrary.Models
{
    public class GameMessage
    {
        public GameMessage() { }

        public GameMessage(int gameId, string message, int recepientUserId)
        {
            this.GameId = gameId;
            this.Message = message;
            this.RecepientUserId = recepientUserId;
        }

        public int Id { get; set; }
        [Required]
        public string Message { get; set; }


        public int GameId { get; set; }
        public Game Game { get; set; }

        public int RecepientUserId { get; set; }
        public User RecepientUser { get; set; }

        public bool IsDelivered { get; set; }
    }
}
