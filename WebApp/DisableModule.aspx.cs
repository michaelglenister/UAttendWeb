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
    public partial class DisableModule : System.Web.UI.Page
    {
        static int moduleID;

        protected void Page_Load(object sender, EventArgs e)
        {
            moduleID = Convert.ToInt32(Request.QueryString["id"]);

            //get module name
            ModuleHandler moduleHandler = new ModuleHandler();
            Module module = new Module();
            module = moduleHandler.GetModuleDetails(Convert.ToInt32(moduleID));

            litHeader.Text = "<div class='alert alert-info'>" + module.ModuleCode + "</div>";
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            ModuleHandler moduleHandler = new ModuleHandler();

            moduleHandler.DisableModule(moduleID);
            Response.Redirect("Modules.aspx");
        }

        protected void btnDeny_Click(object sender, EventArgs e)
        {
            Response.Redirect("Modules.aspx");
        }
    }
}