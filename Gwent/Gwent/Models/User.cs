using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.ComponentModel;

namespace Gwent.Models
{
    public class User
    {
        public User() { }

        public User(int id, string firstName, string lastName, string emailAddress, string hashedPassword)
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
    }
}