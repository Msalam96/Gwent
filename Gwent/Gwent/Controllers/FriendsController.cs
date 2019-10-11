using Gwent.FormModels;
using Gwent.Models;
using Gwent.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gwent.Controllers
{
    [Authorize]
    public class FriendsController : BaseController
    {
        public ActionResult Index ()
        {
            CustomPrincipal currentUser = (CustomPrincipal)User;

            return View();
        }

        public ActionResult AddFriend()
        {
            CustomPrincipal currentUser = (CustomPrincipal)User;
            AddFriend newFriend = new AddFriend();
            newFriend.firstUserId = currentUser.User.Id;
            return View(newFriend);
        }

        [HttpPost]
        public ActionResult AddFriend(AddFriend newFriend)
        {

            UserRelationship newRelationship = new UserRelationship(newFriend.firstUserId, newFriend.secondUserId, false);
            return View(/* Add ViewModel in here */);
        }
    }
}