using crud.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crud
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly AccountDAL accountDAL = new AccountDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string email = txtEmail.Text;
            string password = txtPassword.Text;

            (bool loginSuccessful, string errorMessage) = accountDAL.Login(email, password);

            if (loginSuccessful)
            {
                //calling session
                Session["Email"] = email;
                // Login successful, redirect to the home page or perform other actions
                Response.Redirect("Default.aspx");
            }
            else
            {
                // Invalid credentials, display an error message or perform other actions
                lblError.Text = errorMessage;
            }
        }
        protected void btnLoginWithGoogle_Click(object sender, EventArgs e)
        {
            string clientId = ConfigurationManager.AppSettings["GoogleClientId"];
            string redirectUri = "http://localhost:61113/CallbackPage.aspx"; // Update with your actual redirect URI

            string authUrl = $"https://accounts.google.com/o/oauth2/auth?client_id={clientId}&redirect_uri={redirectUri}&response_type=code&scope=https://www.googleapis.com/auth/plus.login";

            // Redirect the user to the Google OAuth authorization URL
            Response.Redirect(authUrl);
        }



    }
}