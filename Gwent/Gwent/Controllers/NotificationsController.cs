using Gwent.FormModels;
using Gwent.Security;
using GwentSharedLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gwent.Controllers
{
    public class NotificationsController : Controller
    {
        private Context context;
        public NotificationsController()
        {
            context = new Context();
        }
        // GET: Notifications
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            NotificationModel model = new NotificationModel();
            CustomPrincipal currentUser = (CustomPrincipal)User;
            model.SenderUserId = currentUser.User.Id;
            model.PopulateSelectLists(context);
            return View("Create", model);
        }
        
    }
}