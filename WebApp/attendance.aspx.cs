using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class attendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSubjectAverage_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubjectAverage.aspx");
        }

        protected void btnStudentAverage_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentAverage.aspx");
        }

        protected void btnStudentDetail_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentDetail.aspx");
        }
    }
}