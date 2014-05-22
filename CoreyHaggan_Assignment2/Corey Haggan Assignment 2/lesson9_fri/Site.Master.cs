using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoreyHaggan_Assignment2
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.IsInRole("Admin")) {
                NavigationMenu.Items[1].Enabled = true; 
                NavigationMenu.Items[2].Enabled = false;
            }
            if (HttpContext.Current.User.IsInRole("User"))
            {
                NavigationMenu.Items[1].Enabled = false;
                NavigationMenu.Items[2].Enabled = true;

            }

        }
    }
}
