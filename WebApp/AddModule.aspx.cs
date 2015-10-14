using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BLL;
using DAL;

namespace WebApp
{
    public partial class AddModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddModule_Click(object sender, EventArgs e)
        {
            int lastID = 0;

            Module newModule = new Module();
            newModule.ModuleCode = txtModuleCode.Value;
            newModule.LecturerID = Convert.ToInt32(Session["lecturerID"]);
            newModule.Date = DateTime.Now;

            ModuleHandler moduleHandler = new ModuleHandler();

            lastID = moduleHandler.AddNewModule(newModule);
            if (lastID > 0)
            {
                litHeader.Text = "Module added";

                Response.Redirect("AddStudents.aspx?module=" + lastID);
            }
            else
	        {
                litHeader.Text = "Failed to add module";
	        }
        }
    }
}