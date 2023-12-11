using Microsoft.Owin.Security.Google;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

[assembly: OwinStartup(typeof(crud.Startup))]

namespace crud
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var googleClientId = ConfigurationManager.AppSettings["GoogleClientId"];
            var googleClientSecret = ConfigurationManager.AppSettings["GoogleClientSecret"];

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = googleClientId,
                ClientSecret = googleClientSecret,
                CallbackPath = new PathString("/signin-google")
            });
        }
    }
}