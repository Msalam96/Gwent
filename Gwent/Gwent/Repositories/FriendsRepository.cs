using Gwent.Data;
using Gwent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gwent.Repositories
{
    public class FriendsRepository
    {
        private Context context;

        public FriendsRepository (Context context)
        {
            this.context = context;
        }

        //public List<User> GetUsersList ()
        //{

        //}

        public void GetFriendsById (int id)
        {
            //Create and retuern new viewModel to display friends using usernames
        }
    }
}