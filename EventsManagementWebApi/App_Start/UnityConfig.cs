using EventsManagementWebApi.Domain.Repositories;
using EventsManagementWebApi.Domain.Services;
using EventsManagementWebApi.Presistance.Repositories;
using EventsManagementWebApi.Services;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace EventsManagementWebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

           container.RegisterType<IUserService, UserService>();
           container.RegisterType<IUserRepository, UserRepository>();
           container.RegisterType<IUnitOfWork, UnitOfWork>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}