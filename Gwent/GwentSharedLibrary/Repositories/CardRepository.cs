using GwentSharedLibrary.Data;
using GwentSharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GwentSharedLibrary.Repositories
{
    public class CardRepository
    {
        public Context _context;

        public CardRepository(Context context)
        {
            _context = context;
        }

        //public List<Card> GetCards() {
        //    return _context.Cards
        //        .Include(c => c.Deck)
        //        .ToList();
        //}
    }
}