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
    public partial class Modules : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateTableEnabledModules();
            }
        }
        protected void populateTableEnabledModules()
        {
            int lecturerID = Convert.ToInt32(Session["lecturerID"]);
            litAlert.Text = "";
            //generate a table to list all modules
            ModuleHandler moduleHandler = new ModuleHandler();

            int moduleID = 0;
            string htmlOutput = "";

            List<Module> listModules = moduleHandler.GetModuleList(lecturerID);

            //Check to make sure there is modules in the system assigned to the lecturer
            if (listModules == null)
                litAlert.Text = "<div class='alert alert-warning'>There are currently no modules enabled on the system</div>";
            else
            {
                htmlOutput = "<tr><th>Module code</th><th>Start month & year</th><th>Student list</th><th>Disable module</th></tr>";
                //add modules to table as it is generated
                for (int i = 0; i < listModules.Count; i++)
                {
                    moduleID = listModules[i].ModuleID;
                    htmlOutput += "<tr><td>" + listModules[i].ModuleCode + "</td><td>" + listModules[i].Date.ToString("MM / yyyy") + " </td><td><a href=\"ViewStudents.aspx?module=" + listModules[i].ModuleID + "\">View</a></td><td><a href=\"DisableModule.aspx?id=" + listModules[i].ModuleID + "\"/>Disable</a></td></tr>\n";
                }
            }
            litModuleList.Text = htmlOutput;
        }

        protected void populateTableDisabledModules()
        {
            int lecturerID = Convert.ToInt32(Session["lecturerID"]);
            litAlert.Text = "";
            //generate a table to list all modules
            ModuleHandler moduleHandler = new ModuleHandler();

            int moduleID = 0;
            string htmlOutput = "<tr><th>Module code</th><th>Student list</th><th>Enable module</th></tr>";

            List<Module> listModules = moduleHandler.GetDisabledModuleList(lecturerID);

            //Check to make sure there is modules in the system assigned to the lecturer
            if (listModules == null)
                litAlert.Text = "<div class='alert alert-warning'>There are currently no modules disabled on the system</div>";
                
            else
            {
                //add modules to table as it is generated
                for (int i = 0; i < listModules.Count; i++)
                {
                    moduleID = listModules[i].ModuleID;
                    htmlOutput += "<tr><td>" + listModules[i].ModuleCode + "</td><td><a href=\"ViewStudents.aspx?module=" + listModules[i].ModuleID + "\"/>View</a></td><td><a href=\"EnableModule.aspx?id=" + listModules[i].ModuleID + "\"/>Enable</a></td></tr>\n";
                }
            }
            litModuleList.Text = htmlOutput;
        }

        protected void rdoShowEnabled_CheckedChanged(object sender, EventArgs e)
        {
            //enable delete button
            populateTableEnabledModules();
        }

        protected void rdoShowDisabled_CheckedChanged(object sender, EventArgs e)
        {
            //disable delete button
            populateTableDisabledModules();
        }

        protected void btnAddModule_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddModule.aspx");
        }
    }
}