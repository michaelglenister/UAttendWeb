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
    public partial class rollcallHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //display list of modules linked to the lecturer
            int lecturerID = Convert.ToInt32(Session["LecturerID"]);
            ModuleHandler moduleHandler = new ModuleHandler();

            if (!Page.IsPostBack)
            {
                dlModules.DataSource = moduleHandler.GetModuleList(lecturerID);
                dlModules.DataTextField = "ModuleCode";
                dlModules.DataValueField = "ModuleID";
                dlModules.DataBind();
            }
        }

        protected void btnGetHistory_Click(object sender, EventArgs e)
        {
            RollCallHandler rollCallHandler = new RollCallHandler();
            int moduleID = Convert.ToInt32(dlModules.SelectedValue);
            List<RollCall> listRollCalls = rollCallHandler.GetRollCallList(moduleID);
            
            litAlert.Text = "";

            //generate a table to list all modules
            string htmlOutput = "";

            //Check to make sure there is modules in the system assigned to the lecturer
            if (listRollCalls == null)
                litAlert.Text = "<div class='alert alert-warning'>There are no previous roll calls for this module</div>";
            else
            {
                htmlOutput = "<thead><tr><th>Date and time <i class='fa fa-sort'></i></th><th>Pin Code <i class='fa fa-sort'></i></th><th>Status <i class='fa fa-sort'></i></th><th>Toggle Status</th></tr></thead>";
                //add modules to table as it is generated
                for (int i = 0; i < listRollCalls.Count; i++)
                {
                    if (listRollCalls[i].AutoDisable != "")
                    {
                        DateTime autoDisableDate = DateTime.Parse(listRollCalls[i].AutoDisable);

                        if (DateTime.Compare(autoDisableDate, DateTime.Now) < 0)
                        {
                            //auto disabl date reached, disable roll call
                            rollCallHandler.EndRollCall(listRollCalls[i].RollCallID);
                            listRollCalls[i].Status = "disabled";
                        }
                    }

                    moduleID = listRollCalls[i].ModuleID;
                    if (listRollCalls[i].Status == "enabled")
                    {
                        htmlOutput += "<tr><td>" + listRollCalls[i].TimeOfRollCall + "</td><td>" + listRollCalls[i].RollCallID + "</td><td>" + listRollCalls[i].Status + " </td><td><a href=\"ToggleRollCall.aspx?id=" + listRollCalls[i].RollCallID + "\">Make Disabled</a></td></tr>\n";
                    }
                    else
                    {
                        htmlOutput += "<tr><td>" + listRollCalls[i].TimeOfRollCall + "</td><td>" + listRollCalls[i].RollCallID + "</td><td>" + listRollCalls[i].Status + " </td><td><a href=\"ToggleRollCall.aspx?id=" + listRollCalls[i].RollCallID + "\">Make Enabled</a></td></tr>\n";
                    }
                }
            }
            litRollCallList.Text = htmlOutput;
        }
    }
}