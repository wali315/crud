using System;

namespace crud
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool IsLoggedIn
        {
            get
            {
                return Session["Email"] != null;
            }
        }

        public string UserName
        {
            get
            {
                return Session["Email"] as string;
            }
        }
    }
}
