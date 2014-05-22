using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoreyHaggan_Assignment2
{
    public partial class admin : System.Web.UI.Page
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

        protected void gvCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //instantiate an instance of the User class
            BusinessRules.CUser objUser = new BusinessRules.CUser();

            //Define the id of the record
            objUser.CourseID = Convert.ToInt32(gvCourses.DataKeys[e.RowIndex].Values["CourseID"]);

            //Call the delete method
            objUser.deleteUsers();

            //repopulate the grid with our existing function
            getCourses();
        }

        protected void gvCourses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Attributes.Add("onclick", "return confirm('Are you sure?');");
        }
    }
    }
