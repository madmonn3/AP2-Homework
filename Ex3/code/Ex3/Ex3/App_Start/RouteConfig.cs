using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ex3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "MomentaryLocation",
                url: "display/{ip}/{port}",
                defaults: new { controller = "Display", action = "ConnectAndGetLocation" }
            );

            routes.MapRoute(
                name: "DisplayRoute",
                url: "display/{ip}/{port}/{rate}",
                defaults: new { controller = "Display", action = "ConnectAndGetLocation" }
            );

            routes.MapRoute(
                name: "GetFlightInfo",
                url: "display/GetFlightInfo",
                defaults: new { controller = "Display", action = "GetFlightInfo" }
            );

            routes.MapRoute(
                name: "SaveRoute",
                url: "save/{ip}/{port}/{rate}/{limit}/{filename}",
                defaults: new { controller = "Display", action = "ConnectAndSave" }
            );

            routes.MapRoute(
                name: "SaveXml",
                url: "display/SaveXml",
                defaults: new { controller = "Display", action = "SaveXml" }
            );

            routes.MapRoute(
                name: "GetXml",
                url: "display/GetXml",
                defaults: new { controller = "Display", action = "GetXml" }
            );
        }
    }
}
