using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace CoreyHaggan_Assignment2
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            //instantiate the user class
            BusinessRules.CUser objUser = new BusinessRules.CUser();
            string role = objUser.login(txtUsername.Text, txtPassword.Text);

            //try logging in, show an error if it fails
            if (role == "")
            {
                lblError.Text = "Invalid Login";
            }
            else
            {
                //login is valid
                //create an authentication ticket
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1, //version
                    txtUsername.Text, //identity
                    DateTime.Now, //issue date/time
                    DateTime.Now.AddMinutes(30), //30 min default expiry
                    false, //don't persist across browser sessions
                    role, //user role
                    FormsAuthentication.FormsCookiePath);

                //encrypt the cookie
                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                //save the cookie to the browser
                Response.Cookies.Add(cookie);

                Response.Redirect("user.aspx", true);
            }


        }
    }
}