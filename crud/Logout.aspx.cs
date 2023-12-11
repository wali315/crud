using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace crud
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Clear the session variables related to login
            Session["Email"] = null;

            // Optionally, you can redirect the user to a specific page after logout
            Response.Redirect("~/Default.aspx");

        }
    }
}