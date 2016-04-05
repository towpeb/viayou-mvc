using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using ViaYou.Data;
using ViaYou.Data.Repositories;
using ViaYou.Domain.Repositories;
using ViaYou.Domain.Users;

namespace ViaYou.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            //identity injections
            container.RegisterType<DbContext, ViaYouDataContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => HttpContext.Current.GetOwinContext().Authentication));

            //repositories
            container.RegisterType<IContainedInRepository, ContainedInRepository>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<ITravelRepository, TravelRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}