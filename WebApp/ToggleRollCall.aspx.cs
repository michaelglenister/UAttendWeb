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
    public partial class ToggleRollCall : System.Web.UI.Page
    {
        static int rollCallID;
        static string status;

        protected void Page_Load(object sender, EventArgs e)
        {
            rollCallID = Convert.ToInt32(Request.QueryString["id"]);

            //get module name
            RollCallHandler rollCallHandler = new RollCallHandler();
            RollCall rollCall = new RollCall();
            rollCall = rollCallHandler.GetRollCallDetails(Convert.ToInt32(rollCallID));
            status = rollCall.Status;

            if (status == "enabled")
            {
                litHeader.Text = "<div class='alert alert-info'>Disable roll call of " + rollCall.TimeOfRollCall + "</div>";
            }
            else
            {
                litHeader.Text = "<div class='alert alert-info'>Enable roll call of " + rollCall.TimeOfRollCall + "</div>";
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (status == "enabled")
            {
                RollCallHandler rollCallHandler = new RollCallHandler();
                rollCallHandler.EndRollCall(rollCallID);
            }
            else
            {
                RollCallHandler rollCallHandler = new RollCallHandler();
                rollCallHandler.ResumeRollCall(rollCallID);
            }

            Response.Redirect("RollCallHistory.aspx");
        }

        protected void btnDeny_Click(object sender, EventArgs e)
        {
            Response.Redirect("RollCallHistory.aspx");
        }
    }
}