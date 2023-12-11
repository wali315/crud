using Google.Apis.Auth.OAuth2;
using Google.Apis.Plus.v1;
using Google.Apis.Plus.v1.Data;
using System;
using System.Configuration;
using System.Threading;

namespace crud
{
    public partial class CallbackPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string clientId = ConfigurationManager.AppSettings["GoogleClientId"];
            string clientSecret = ConfigurationManager.AppSettings["GoogleClientSecret"];
            string redirectUri = "http://localhost:61113/CallbackPage.aspx"; // Update with your actual redirect URI

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret
                },
                new[] { PlusService.Scope.UserinfoProfile },
                "user",
                CancellationToken.None).Result;

            // Get user info
            var service = new PlusService(new Google.Apis.Services.BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "webforgoogleauth", // Provide a meaningful name
            });

            Person me = service.People.Get("me").Execute();

            // Use 'me' to get user information
            // Perform additional logic based on the user info
            // For example, you might want to associate the Google account with an existing user in your system.

            // Redirect or perform other actions as needed
            Response.Redirect("Default.aspx");
        }
    }
}
