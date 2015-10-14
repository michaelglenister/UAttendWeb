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
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FirstName"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            Lecturer lecturer = new Lecturer();
            LecturerHandler lecturerHandler = new LecturerHandler();

            lecturer = lecturerHandler.GetLecturerDetails(Convert.ToInt32(Session["LecturerID"]));

            if (lecturer.Role == 2)
            {
                litAdminMenu.Text = "<h3>Admin tools</h3><br /><a href='AddModuleAdmin.aspx' class='btn btn-success'>Add Module</a><br /><br />";
                //business button for litAdminMenu
                //<a href='BusinessSettings.aspx' class='btn btn-success'>Business Settings</a>
            }

        }
    }
}