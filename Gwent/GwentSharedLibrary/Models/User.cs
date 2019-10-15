using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GwentSharedLibrary.Models
{
    public class User
    {
        public User() {
            //DeckUsers = new List<DeckUser>();
            DeckUsers = new List<DeckUser>();
        }

        public User(int id, string firstName, string lastName, string emailAddress, string hashedPassword)
            : this()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            HashedPassword = hashedPassword;
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string EmailAddress { get; set; }
        [Required]
        public string HashedPassword { get; set; }

        //public DeckUser DeckUser { get; set; }

        //public void AddDeck (Deck deck)
        //{
        //    DeckUser.Deck = deck;
        //    DeckUser.User = this;
        //}

        public List<DeckUser> DeckUsers { get; set; }
        public void AddDeck(Deck deck)
        {
            DeckUsers.Add(new DeckUser()
            {
                Deck = deck,
                User = this
            });
        }
    }
}