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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblInvalidEmail.Text = "";
            lblConfirmPassword.Text = "";
            string option = "";
            double num = 0;

            Lecturer lecturer = new Lecturer();

            lecturer.Email = txtEmail.Value;
            lecturer.Password = txtPassword.Value;
            lecturer.FirstName = txtFirstName.Value;
            lecturer.Surname = txtSurname.Value;

            LecturerHandler lecturerHandler = new LecturerHandler();

            if (txtPassword.Value == txtConfirmPassword.Value)
            {
                if (lecturerHandler.ValidateEmail(txtEmail.Value) == false/* && double.TryParse(option, out num) == true*/)
                {
                    if (lecturerHandler.AddNewLecturer(lecturer) == false)
                        Response.Redirect("Login.aspx?registered=1");
                }

                else if (lecturerHandler.ValidateEmail(txtEmail.Value) == true)
                {
                    lblInvalidEmail.Text = "This E-Mail address is already in use";
                    txtPassword.Attributes.Add("value", txtPassword.Value);
                    txtConfirmPassword.Attributes.Add("value", txtConfirmPassword.Value);
                }

                else if (double.TryParse(option, out num) == false)
                {
                    lblInvalidEmail.Text = "";
                    txtPassword.Attributes.Add("value", txtPassword.Value);
                    txtConfirmPassword.Attributes.Add("value", txtConfirmPassword.Value);
                }
            }
            else
            {
                lblConfirmPassword.Text = "Passwords do not match";
            }
            
        }
    }
}