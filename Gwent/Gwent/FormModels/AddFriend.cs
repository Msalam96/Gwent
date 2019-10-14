using GwentSharedLibrary.Models;
using System.Collections.Generic;


namespace Gwent.FormModels
{
    public class AddFriend
    {
        public int firstUserId { get; set; }
        public int secondUserId { get; set; }
        public bool isAvailable { get; set; }

        public List<User> Users { get; set; }
    }
}