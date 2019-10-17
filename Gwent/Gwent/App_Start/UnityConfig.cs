using GwentSharedLibrary.Data;
using GwentSharedLibrary.Repositories;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Gwent
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<Context>();
            container.RegisterType<GameRepository>();
            container.RegisterType<AuthenticationRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}