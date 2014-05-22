using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoreyHaggan_Assignment2
{
    public partial class AddUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                getUsers();
            }
        }

        protected void getUsers()
        {
            //create an instance of Csupplier class
            BusinessRules.CUser objUsers = new BusinessRules.CUser();

            //set the companyID & retrieve the record
            objUsers.CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);
            objUsers.getUsers();

            txtStudentName.Text = objUsers.StudentName;
            txtCourseName.Text = objUsers.CourseName;
            txtCourseTime.Text = objUsers.CourseTime;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //create an instance of Csupplier class
            BusinessRules.CUser objUsers = new BusinessRules.CUser();

            //populate the Course properties with values from the UI
            objUsers.CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);
            objUsers.StudentName = txtStudentName.Text;
            objUsers.CourseName = txtCourseName.Text;
            objUsers.CourseTime = txtCourseTime.Text;
            //invoke the save method in the class library
            objUsers.saveUsers();

            //take the user back to the updated list
            Response.Redirect("home.aspx", true);

        }
    }
}