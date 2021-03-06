    public void Configuration(IAppBuilder app)
    {
        app.UseCookieAuthentication(new CookieAuthenticationOptions
        {
            AuthenticationMode = AuthenticationMode.Active,
            AuthenticationType = DefaultApplicationTypes.ApplicationCookie,
            ExpireTimeSpan = TimeSpan.FromMinutes(48),
            LoginPath = new PathString("/NewAccount/LogOn"),
            Provider = new CookieAuthenticationProvider()
            {
                OnApplyRedirect = ctx =>
                {
                    var response = ctx.Response;
                    if (!IsApiResponse(ctx.Response))
                    {
                        response.Redirect(ctx.RedirectUri);
                    }
                }
            }
        });
    }
    private static bool IsApiResponse(IOwinResponse response)
    {
        var responseHeader = response.Headers;
        if (responseHeader == null) 
            return false;
        return (responseHeader["Suppress-Redirect"] == "True");
    }
