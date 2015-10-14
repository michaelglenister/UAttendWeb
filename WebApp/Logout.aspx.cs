using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LectureID"] = null;
            Session["FirstName"] = null;
            Session["Surname"] = null;
            Response.Redirect("Default.aspx?logout=1");
        }
    }
}