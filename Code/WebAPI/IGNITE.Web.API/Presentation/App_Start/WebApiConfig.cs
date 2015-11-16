using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace IGNITE.Web.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { controller = RouteParameter.Optional, action = RouteParameter.Optional, id = RouteParameter.Optional }
            );

            var container = new DependencyRegister();
            container.Register(config);
        }
    }
}
