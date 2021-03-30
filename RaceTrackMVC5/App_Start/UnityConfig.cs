using RaceTrack.Models;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace RaceTrackMVC5
{
    public static class UnityConfig
    {
        //This the IoC(Inversion of Control) Container that Injects service.
        //Here we map Interface to its class and IoC container maps the dependency injection at Runtime.
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //register our SQLVehicleRepository Class and Interface IVehicleRepository in this
            container.RegisterType<IVehicleRepository, SQLVehicleRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}