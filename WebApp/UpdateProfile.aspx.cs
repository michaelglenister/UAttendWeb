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
    public partial class UpdateProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int lecturerID = (int)Session["LecturerID"];

            if (lecturerID == 0)
                Response.Redirect("Login.aspx");

            LecturerHandler lecturerHandler = new LecturerHandler();
            Lecturer lecturer = new Lecturer();
            lecturer = lecturerHandler.GetLecturerDetails(lecturerID);

            if (!IsPostBack)
            {
                try
                {
                    txtEmail.Value = lecturer.Email;
                    txtFirstName.Value = lecturer.FirstName;
                    txtSurname.Value = lecturer.Surname;
                }
                catch (NullReferenceException)
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            int lecturerID = 0;
            try
            {
                lecturerID = Convert.ToInt32(Request.QueryString["id"]);
            }
            catch (NullReferenceException)
            {

            }
            LecturerHandler lecturerHandler = new LecturerHandler();
            Lecturer lecturer = new Lecturer();
            lecturer = lecturerHandler.GetLecturerDetails(lecturerID);

            lecturer.LecturerID = lecturerID;
            lecturer.FirstName = txtFirstName.Value;
            lecturer.Surname = txtSurname.Value;

            lecturer.Email = txtEmail.Value;
            lecturer.Password = txtPassword.Value;

            if (txtPassword.Value == "")
                lecturerHandler.UpdateLecturer(lecturer);
            else if (txtPassword.Value != "")
                lecturerHandler.UpdateLecturerWithPassword(lecturer);

            Response.Redirect("Profile.aspx?id=" + lecturerID.ToString());
        }
    }
}