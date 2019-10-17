using Gwent.FormModels;
using GwentSharedLibrary.Models;
using GwentSharedLibrary.Repositories;
using Gwent.Security;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Gwent.Controllers
{
    [Authorize]
    public class FriendsController : BaseController
    {
        public ActionResult Index ()
        {
            CustomPrincipal currentUser = (CustomPrincipal)User;
            FriendsRepository repository = new FriendsRepository(context);
            List<UserRelationship> userRelationships = repository.GetUserRelationshipsById(currentUser.User.Id);
            return View(userRelationships);
        }

        public ActionResult AddFriend()
        {
            FriendsRepository repository = new FriendsRepository(context);
            CustomPrincipal currentUser = (CustomPrincipal)User;
            AddFriend newFriend = new AddFriend();
            //newFriend.firstUserId = currentUser.User.Id;
            List<User> tempList = repository.GetUsersListExceptId(currentUser.User.Id);
            newFriend.Users = new List<User>();
            foreach (var user in tempList)
            {
                if (!repository.IsFriend(currentUser.User.Id, user.Id))
                {
                    newFriend.Users.Add(user);
                }
            }
            //newFriend.Users = repository.GetUsersListExceptId(currentUser.User.Id);
            return View(newFriend);
        }

        [HttpPost]
        public ActionResult AddFriend(int id)
        {
            CustomPrincipal currentUser = (CustomPrincipal)User;
            UserRelationship newRelationship = new UserRelationship(currentUser.User.Id, id, false);
            FriendsRepository repository = new FriendsRepository(context);
            repository.AddFriend(newRelationship);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult AcceptRequest (int id)
        {
            FriendsRepository repository = new FriendsRepository(context);
            repository.AcceptRequestById(id);
            return RedirectToAction("Index");
        }
    }
}