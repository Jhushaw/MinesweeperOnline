using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MsOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
             routes.MapRoute(
                "Default",                                              // Route name
                "",                           // URL with parameters
                new { controller = "Scores", action = "getAllScores", id = "" }  // Parameter defaults
            );
           ///////////////////////////////USER////////////////////////////////////////
            routes.MapRoute(
                name: "Login",
                url: "login",//url will now respond to any action typed after test uri
                defaults: new { controller = "User", action = "Log", id = UrlParameter.Optional }

            );
            routes.MapRoute(
                name: "Profile",
                url: "profile",//url will now respond to any action typed after test uri
                defaults: new { controller = "User", action = "Profile", id = UrlParameter.Optional }

            );
            routes.MapRoute(
                name: "logout",
                url: "logout",//url will now respond to any action typed after test uri
                defaults: new { controller = "User", action = "Logout", id = UrlParameter.Optional }

            );
            routes.MapRoute(
              name: "register",
              url: "register",//url will now respond to any action typed after test uri
              defaults: new { controller = "User", action = "Reg", id = UrlParameter.Optional }
          );
            routes.MapRoute(
                name: "doLogin",
                url: "User/{action}",//url will now respond to any action typed after test uri
                defaults: new { controller = "User", action = "Login" }
            );
            routes.MapRoute(
                name: "doRegistration",
                url: "user/{action}",//url will now respond to any action typed after test uri
                defaults: new { controller = "User", action = "Register" }
            );
            ///////////////////GAME//////////////////////////////////////////////
            routes.MapRoute(
                name: "selectdifficulty",
                url: "game/{action}",//url will now respond to any action typed after test uri
                defaults: new { controller = "Game", action = "SelectDifficulty" }
            );
            routes.MapRoute(
                name: "play",
                url: "game/play",//url will now respond to any action typed after test uri
                defaults: new { controller = "Game", action = "Play" }
            );
            routes.MapRoute(
                name: "scores",
                url: "scores",//url will now respond to any action typed after test uri
                defaults: new { controller = "Scores", action = "getScores" }
            );
        }
    }
}
