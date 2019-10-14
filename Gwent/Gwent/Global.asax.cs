using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Data.Entity;
using GwentSharedLibrary.Data;
using System.Security.Principal;
using Gwent.Security;
using GwentSharedLibrary.Repositories;
using GwentSharedLibrary.Models;
using System.Threading;
using System.Web.Security;

namespace Gwent
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            UnityConfig.RegisterComponents();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer(new DatabaseIntializer());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_PostAuthenticateRequest()
        {
            IPrincipal user = HttpContext.Current.User;
            if (user.Identity.IsAuthenticated && user.Identity.AuthenticationType == "Forms")
            {
                FormsIdentity formsIdentity = (FormsIdentity)user.Identity;
                FormsAuthenticationTicket ticket = formsIdentity.Ticket;

                CustomIdentity customIdentity = new CustomIdentity(ticket);
                string currentUserEmailAddress = ticket.Name;

                using (var context = new Context())
                {
                    AuthenticationRepository repository = new AuthenticationRepository(context);
                    User currentUser = repository.GetByEmail(currentUserEmailAddress);

                    CustomPrincipal customPrincipal = new CustomPrincipal(customIdentity, currentUser);
                    HttpContext.Current.User = customPrincipal;
                    Thread.CurrentPrincipal = customPrincipal;
                }
            }
        }
    }
}