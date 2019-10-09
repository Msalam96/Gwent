using Gwent.Data;
using Gwent.Models;
using Gwent.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Gwent.Controllers
{
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