using GwentSharedLibrary.Data;
using GwentSharedLibrary.Repositories;
using System.Web.Http;
using Unity;
using WebApiResolver = Unity.WebApi.UnityDependencyResolver;
using MvcResolver = Unity.Mvc5.UnityDependencyResolver;
using System.Web.Mvc;

namespace Gwent
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<Context>();
            container.RegisterType<NotificationsRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = 
                new WebApiResolver(container);
            DependencyResolver.SetResolver(new MvcResolver(container)); 
        }
    }
}