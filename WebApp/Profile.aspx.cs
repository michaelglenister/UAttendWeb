using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using BLL;

namespace WebApp
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int lecturerID = (int)Session["LecturerID"];

            if (lecturerID == 0)
                Response.Redirect("Login.aspx");

            LecturerHandler lecturerHandler = new LecturerHandler();
            Lecturer lecturer = new Lecturer();
            lecturer = lecturerHandler.GetLecturerDetails(lecturerID);

            litLecturerName.Text = "Profile for " + lecturer.FirstName + " " + lecturer.Surname;

            txtEmail.Value = lecturer.Email;
            txtFirstName.Value = lecturer.FirstName;
            txtSurname.Value = lecturer.Surname;

        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            int lecturerID = (int)Session["LecturerID"];
            Response.Redirect("UpdateProfile.aspx?id=" + lecturerID.ToString());
        }
    }
}