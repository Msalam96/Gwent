using System.Web.Mvc;

namespace Gwent.Controllers
{
    [Authorize]
    public class GameBoardController : Controller
    {
        // GET: GameBoard
        public ActionResult Index()
        {
            return View();
        }
    }
}