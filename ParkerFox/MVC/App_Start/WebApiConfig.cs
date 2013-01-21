using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MVC.Components;

namespace MVC
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("blog", "api/{controller}/{blogId}/post/{postId}", new {Action = "GetPost"});

            config.Routes.MapHttpRoute(
                name: "AddressLookup",
                routeTemplate: "api/address/{how}/{value}");

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MessageHandlers.Add(new LoggingDelegatingHandler());
            
            config.Filters.Add(new MyApiActionFilter());
        }
    }
}
