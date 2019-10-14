using GwentSharedLibrary.Data;
using GwentSharedLibrary.Models;
using GwentSharedLibrary.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Gwent.Controllers
{
    [Authorize]
    public class CardController : Controller
    {
        private Context context;

        public CardController()
        {
            context = new Context();
        }

        // GET: Card
        public ActionResult Index()
        {
            var repository = new CardRepository(context);
            List<Card> cards = repository.GetCards();
            return View(cards);
        }
    }
}