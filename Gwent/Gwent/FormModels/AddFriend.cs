using Gwent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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