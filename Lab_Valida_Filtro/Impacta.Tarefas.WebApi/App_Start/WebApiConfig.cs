using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Impacta.Tarefas.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

			//fonte site Microsoft docs
			//Remove the XML formatter
			//A partir de agora , não retorna mais em format XML
			config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
