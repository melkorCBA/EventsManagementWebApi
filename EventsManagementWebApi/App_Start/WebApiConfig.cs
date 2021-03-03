using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Routing;

namespace EventsManagementWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { action = RouteParameter.Optional ,  id = RouteParameter.Optional }
            //);

            //// POST /api/{resource}/{action}
            //config.Routes.MapHttpRoute(
            //    name: "Web API RPC Post",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //    );


            // returns json instead of XML by default
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
