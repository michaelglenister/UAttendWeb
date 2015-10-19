using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.Drawing.Imaging;
using MessagingToolkit.QRCode.Codec.Data;
using MessagingToolkit.QRCode.Codec;

using DAL;
using BLL;
using System.Globalization;

namespace WebApp
{
    public partial class RollCallSession : System.Web.UI.Page
    {
        static int rollCallID;

        protected void Page_Load(object sender, EventArgs e)
        {
            int lecturerID = Convert.ToInt32(Session["LecturerID"]);
            ModuleHandler moduleHandler = new ModuleHandler();
            //litAutoDisable.Text = "<input id='txtTime' runat='server' class='form - control required - field' placeholder='Minutes' type='time' required='required'/> <input id = 'txtDate' runat = 'server' class='form - control required - field' placeholder='Date' type='date' required='required'/><br /><br />";
            if (!Page.IsPostBack)
            {
                dlModules.DataSource = moduleHandler.GetModuleList(lecturerID);
                dlModules.DataTextField = "ModuleCode";
                dlModules.DataValueField = "ModuleID";
                dlModules.DataBind();
            }
        }
        
        protected void btnBeginRollCall_Click(object sender, EventArgs e)
        {
            RollCall rollCall = new RollCall();
            RollCallHandler rollCallHandler = new RollCallHandler();

            //add roll call entry to DB
            rollCall.TimeOfRollCall = DateTime.Now.ToString();
            rollCall.ModuleID = Convert.ToInt32(dlModules.SelectedValue);
            //rollCall.Status = "Enabled"; not needed

            rollCallID = rollCallHandler.AddNewRollCall(rollCall);

            //generate and display QR Code and pin
            string encodeQR = rollCallID.ToString();

            QRCodeEncoder encoder = new QRCodeEncoder();
            Bitmap hi = encoder.Encode(encodeQR);
            hi.Save(Server.MapPath("~/temp/" + encodeQR + ".jpg"), ImageFormat.Jpeg);
            QRcode.ImageUrl = "~/temp/" + encodeQR + ".jpg";

            litPin.Text = "<div class='alert alert-info'>Pin: " + rollCallID + "</div>";
            //change interface to suite active roll call session
            btnBeginRollCall.Visible = false;
            dlModules.Visible = false;

            //litAutoDisable.Visible = true;
            txtTime.Visible = true;
            txtDate.Visible = true;
            btnAutoDisable.Visible = true;

            btnPauseRollCall.Visible = true;
            btnEndRollCall.Visible = true;

            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "makeVisible()", true);
        }

        protected void btnPauseRollCall_Click(object sender, EventArgs e)
        {
            RollCallHandler rollCallHandler = new RollCallHandler();

            if (btnPauseRollCall.Text == "Pause Roll Call")
            {
                rollCallHandler.PauseRollCall(rollCallID);
                QRcode.Visible = false;
                litPin.Visible = false;

                btnPauseRollCall.Text = "Resume Roll Call";
            }
            else if (btnPauseRollCall.Text == "Resume Roll Call")
            {
                rollCallHandler.ResumeRollCall(rollCallID);
                QRcode.Visible = true;
                litPin.Visible = true;

                btnPauseRollCall.Text = "Pause Roll Call";
            }
            
        }

        protected void btnEndRollCall_Click(object sender, EventArgs e)
        {
            RollCallHandler rollCallHandler = new RollCallHandler();
            rollCallHandler.EndRollCall(rollCallID);
            Response.Redirect("rollcallSession.aspx");
        }

        protected void btnAutoDisable_Click(object sender, EventArgs e)
        {
            string time = txtTime.Value + ":00";
            string date = txtDate.Value;
            DateTime dateTime = DateTime.ParseExact(date + " " + time, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            //litPin.Text += " " + dateTime.ToString();

            //create database entry with dateTime
            RollCallHandler rollCallHandler = new RollCallHandler();
            rollCallHandler.SetAutoDisable(rollCallID, dateTime.ToString());
        }
    }
}