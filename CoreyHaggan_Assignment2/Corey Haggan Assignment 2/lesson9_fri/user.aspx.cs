using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoreyHaggan_Assignment2
{
    public partial class user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {   //populate supplier grid if page loading for first time
                getCourses();
            }
        }

        protected void getCourses()
        {
            //instantiate an instance of our supplier class
            BusinessRules.CUser objUsers = new BusinessRules.CUser();

            //call the getSuppliers fn & bind the resulting datareader to the grid
            gvCourses.DataSource = objUsers.getUsers();
            gvCourses.DataBind();
        }
    }
}