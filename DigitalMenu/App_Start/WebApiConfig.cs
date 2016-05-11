using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DigitalMenu.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API routes
            // Attribute routing.
            config.MapHttpAttributeRoutes();
            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}