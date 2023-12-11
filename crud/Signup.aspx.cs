using crud.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crud
{
    public partial class Signup : System.Web.UI.Page
    {

        private readonly AccountDAL accountDAL = new AccountDAL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            AccountDAL accountDAL = new AccountDAL();

            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Check if the email already exists
            if (accountDAL.CheckEmailExists(email))
            {
                // Email exists, show an error message
                lblError.Text = "Email already exists. Please choose a different email.";
            }
            else
            {
                // Email does not exist, proceed with the signup
                accountDAL.SignUp(email, password);

                // Redirect to login page or perform other actions after signup
                Response.Redirect("Login.aspx");
            }
        }

    }
}