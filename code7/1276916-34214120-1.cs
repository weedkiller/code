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
    
                config.Routes.MapHttpRoute(
                    name: "route1",
                    routeTemplate: "calculate",
                    defaults: new { controller = "Calculator", action = "Get" });
    
                config.Routes.MapHttpRoute(
                    name: "route2",
                    routeTemplate: "v2/calculate",
                    defaults: new { controller = "Calculator", action = "Get" });
    
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            }
        }
