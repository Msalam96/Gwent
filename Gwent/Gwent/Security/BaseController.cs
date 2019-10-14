using GwentSharedLibrary.Data;
using System.Diagnostics;
using System.Web.Mvc;

namespace Gwent.Security
{
    public class BaseController : Controller
    {
        protected Context context;
        public BaseController()
        {
            context = new Context();

            context.Database.Log = (message) => Debug.WriteLine(message);
        }

        private bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed == true)
            {
                return;
            }

            if (disposing)
            {
                context.Dispose();
            }

            disposed = true;

            base.Dispose(disposing);
        }
    }
}