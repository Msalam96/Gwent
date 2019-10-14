using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gwent.Models
{
    public class UserRelationship
    {
        public UserRelationship() { }
        public UserRelationship(int firstUserId, int secondUserId, bool isAccepted)
        {
            this.FirstUserId = firstUserId;
            this.SecondUserId = secondUserId;
            this.IsAccepted = isAccepted;
        }

        public int Id { get; set; }
        public int FirstUserId { get; set; }            //foreign key
        public int SecondUserId { get; set; }           //foreign key
        public bool IsAccepted { get; set; }

        public User FirstUser { get; set; }
        public User SecondUser { get; set; }
    }

    //TODO Set up foreign key in this class
    //TODO discuss how to search for first-secondUserId and how to assign First-SecondUserId
    //TODO Get current logged in user
    //TODO Friends page (that displays all the friends or friend requests (with button to confirm or deny request))
    //TODO Send Request page: firstUserId = currentLoggedInUser, secondUserId = get from DropDownList (or search bar), isAccepted=false;

}