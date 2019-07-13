using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace eCommerce.Service
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("http://localhost:59337", "*", "*");
            config.EnableCors(cors);

            // Web API configuration and services
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
              name: "DefaultActionApi",
              routeTemplate: "api/{controller}/{id}",
              defaults: new { id = RouteParameter.Optional, controller="Product" }
          );
          
        }
    }
}
