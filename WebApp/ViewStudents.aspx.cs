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
    public partial class ViewStudents : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            string htmlOutput = "";
            int moduleID = Convert.ToInt32(Request.QueryString["module"]);

            //get module name
            ModuleHandler moduleHandler = new ModuleHandler();
            Module module = new Module();
            module = moduleHandler.GetModuleDetails(Convert.ToInt32(moduleID));

            litHeader.Text = "<div class='alert alert-info'>" + module.ModuleCode + "</div>";

            StudentHandler studentHandler = new StudentHandler();
            List<Student> listStudents = studentHandler.GetStudentList(moduleID);

            //Check to make sure there is students in the system assigned to the module
            if (listStudents == null)
                litHeader.Text = "<h3>There are currently no students linked to this module</h3>";
            else
            {
                htmlOutput = "<tr><th>Student number</th><th>Firstname</th><th>Surname</th></tr>\n";
                //add modules to table as it is generated
                for (int i = 0; i < listStudents.Count; i++)
                {
                    htmlOutput += "<tr><td>" + listStudents[i].StudentNumber + "</td><td>" + listStudents[i].FirstName + "</td><td>" + listStudents[i].Surname + "</td></tr>\n";
                }
            }
            litStudentList.Text = htmlOutput;
        }

        protected void btnModule_Click(object sender, EventArgs e)
        {
            Response.Redirect("Modules.aspx");
        }

        protected void btnAddStudents_Click(object sender, EventArgs e)
        {
            int moduleID = Convert.ToInt32(Request.QueryString["module"]);
            Response.Redirect("AddStudents.aspx?module=" + moduleID);
        }
    }
}