using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;

using System.Drawing;
using DAL;
using BLL;

namespace WebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["registered"] == "1")
            {
                litAlert.Text = "<div class='alert alert-success'>Your registration was successfull, you may now login!</div>";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            /*string[] lines = { Request.UserHostName, Request.UserHostAddress, Request.UserAgent, Request.UrlReferrer.ToString() };
            File.WriteAllLines(@"C:\Users\micks\Documents\BitBucket\UAttendWeb\WebApp\temp\" + txtEmail.Value, lines);*/

            string loginResult = "&nbsp;";
            string email = txtEmail.Value;
            string password = txtPassword.Value;
            int lecturerID = 0;
            string redirectURL = "Dashboard.aspx";

            if ((string)Session["LoginRedirect"] != null)
            {
                redirectURL = (string)Session["LoginRedirect"];
            }

            LecturerHandler lecturerHandler = new LecturerHandler();
            Lecturer lecturer = new Lecturer();

            lecturer = lecturerHandler.ValidateLogin(email, password);

            try
            {
                loginResult = lecturer.LecturerID.ToString();
                lecturerID = lecturer.LecturerID;
                Session["LecturerID"] = lecturerID;
                Session["FirstName"] = lecturer.FirstName;
                Session["Surname"] = lecturer.Surname;
                Response.Redirect(redirectURL);
            }
            catch (NullReferenceException)
            {
                litAlert.Text = "<div class='alert alert-danger'>The username or password you entered is incorrect</div>";
            }
        }
    }
}