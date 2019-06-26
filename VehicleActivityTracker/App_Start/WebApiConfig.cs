namespace VehicleActivityTracker
{
    using System.Linq;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Web.Http;
    using Unity;
    using Unity.Lifetime;
    using VehicleActivityTracker.Business;
    using VehicleActivityTracker.Business.Utilities;
    using VehicleActivityTracker.Configurations;
    using VehicleActivityTracker.Resolver;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Dependency Injections
            var container = new UnityContainer();
            container.RegisterType<IVehicleActivityParser, VehicleActivityParser>(new HierarchicalLifetimeManager());
            container.RegisterType<IConfiguration, Configuration>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes

            // Setup Json Formatting for API calls
            var matches = config.Formatters
                    .Where(f => f.SupportedMediaTypes
                                 .Where(m => m.MediaType.ToString() == "application/xml" ||
                                             m.MediaType.ToString() == "text/xml")
                                 .Count() > 0)
                                 .ToList();
            foreach (var match in matches)
            {
                config.Formatters.Remove(match);
            }

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
