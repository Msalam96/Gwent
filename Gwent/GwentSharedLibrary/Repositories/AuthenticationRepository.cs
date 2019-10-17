using GwentSharedLibrary.Data;
using GwentSharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GwentSharedLibrary.Repositories
{
    public class AuthenticationRepository
    {
        private Context context;

        public AuthenticationRepository(Context context)
        {
            this.context = context;
        }

        public void Insert (User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User GetByEmail(string emailAddress)
        {
            return context.Users
                    .Where(u => u.EmailAddress == emailAddress)
                    .SingleOrDefault();
        }

        public User GetById (int id)
        {
            return context.Users
                    .Where(u => u.Id == id)
                    .SingleOrDefault();
        }
    }
}