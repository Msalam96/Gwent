using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GwentSharedLibrary.Models
{
    public class Deck
    {

        public Deck() { }

        public Deck(int id, int userId, string faction) : this()
        {
            Id = id;
            UserId = userId;
            Faction = faction;
        }

        public int Id { get; set; }

        [Required]
        public string Faction { get; set; }

        public int UserId { get; set; }

        User User { get; set; }


    }
}