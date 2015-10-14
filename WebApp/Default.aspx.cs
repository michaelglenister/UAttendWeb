using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string welcomeMessage = "";

            if ((string)Request.QueryString["logout"] == "1")
            {
                welcomeMessage = "You have been logged out successfully<br /><br />";
            }
            /*if (Session["FirstName"] != null && Session["Surname"] != null)
            {
                Response.Redirect("Dashboard.aspx");
                welcomeMessage = "Welcome to EASiBOOK,  " + Session["FirstName"] + " " + Session["Surname"] + "!<br /><br />";
                lblWelcome.Text = welcomeMessage;
            }*/
            else
            {
                welcomeMessage = "Welcome to UAttend<br/><br/>Class attendance tracker<br/><br/>Please login or register to use this website<br /><br />";
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool loggedIn = false;
            if (Session["UserID"] != null)
                loggedIn = true;

            if (loggedIn == true)
                Response.Redirect("Profile.aspx?uid=" + Session["UserID"].ToString());
            else
                Response.Redirect("Login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            bool loggedIn = false;
            if (Session["UserID"] != null)
                loggedIn = true;

            if (loggedIn == true)
                Response.Redirect("Profile.aspx?uid=" + Session["UserID"].ToString());
            else
                Response.Redirect("Register.aspx");
        }
    }
}