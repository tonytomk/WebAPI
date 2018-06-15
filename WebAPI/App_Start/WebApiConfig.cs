using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using WebAPI.Custom;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Services.Replace(typeof(IHttpControllerSelector),
            // new CustomControllerSelector(config));

    //        config.Formatters.JsonFormatter.SupportedMediaTypes
    //.Add(new MediaTypeHeaderValue("application/vnd.pragimtech.students.v1+json"));
    //        config.Formatters.JsonFormatter.SupportedMediaTypes
    //            .Add(new MediaTypeHeaderValue("application/vnd.pragimtech.students.v2+json"));

            config.Routes.MapHttpRoute(
              name: "Version1",
              routeTemplate: "api/v1/students/{id}",
              defaults: new { id = RouteParameter.Optional, controller = "StudentsV1" }
            );
            config.Routes.MapHttpRoute(
                name: "Version2",
                routeTemplate: "api/v2/students/{id}",
                defaults: new { id = RouteParameter.Optional ,controller = "StudentsV2"}
            );

            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
           );
        }
    }
}
