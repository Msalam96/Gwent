using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gwent.Controllers
{
    public class GameBoardController : Controller
    {
        // GET: GameBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}