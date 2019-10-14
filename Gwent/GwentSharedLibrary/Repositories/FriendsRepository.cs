using GwentSharedLibrary.Data;
using GwentSharedLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace GwentSharedLibrary.Repositories
{
    public class FriendsRepository
    {
        private Context context;

        public FriendsRepository (Context context)
        {
            this.context = context;
        }

        public User GetUserById(int id)
        {
            return context.Users
                    .Where(u => u.Id == id)
                    .SingleOrDefault();
        }

        public List<User> GetUsersList()
        {
            return context.Users
                    .ToList();
        }

        public List<User> GetUsersListExceptId(int id)
        {
            return context.Users
                    .Where(u => u.Id != id)
                    .ToList();
        }

        public List<UserRelationship> GetFriendsById (int id)
        {
            return context.UserRelationships
                    .Include(u => u.FirstUser)
                    .Include(u => u.SecondUser)
                    .Where(ur => ur.FirstUserId == id || ur.SecondUserId == id)
                    .ToList();
        }

        public bool IsFriend(int id_1, int id_2)
        {
            return context.UserRelationships
                    .Where(ur => (ur.FirstUserId == id_1 && ur.SecondUserId == id_2) || (ur.FirstUserId == id_2 && ur.SecondUserId == id_1))
                    .Any();

            //TODO verify SQL Query
        }

        public void AddFriend (UserRelationship userRelationship)
        {
            context.UserRelationships.Add(userRelationship);
            context.SaveChanges();
        }

        public void AcceptRequestById (int id)
        {
            UserRelationship relationship = context.UserRelationships
                                                .Where(ur => ur.Id == id)
                                                .SingleOrDefault();
            if (!relationship.IsAccepted)
            {
                relationship.IsAccepted = true;
                context.Entry(relationship).State = EntityState.Modified;
                context.SaveChanges();
                //TODO Update entry through EF
            }
                                          
        }
    }
}