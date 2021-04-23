using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace TrgovinaWebAPI
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
            // Na strani strežnika določi, da se uporablja samo json, naj serializira podatke po referenci ter odstranimo xml formatiranje
            var j = config.Formatters.JsonFormatter;
            j.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
