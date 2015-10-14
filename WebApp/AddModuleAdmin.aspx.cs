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
    public partial class AddModuleAdmin : System.Web.UI.Page
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

            if (lecturer.Role != 2)
            {
                Response.Redirect("Dashboard.aspx");
            }
        }

        protected void btnAddModule_Click(object sender, EventArgs e)
        {
            if (lstLecturers.SelectedIndex == -1)
            {
                lblLecturer.Text = "You must first select a lecturer from the box above.";
            }
            else
            {
                int lecturerID = Convert.ToInt32(lstLecturers.SelectedValue);
                int lastID = 0;

                Module newModule = new Module();
                newModule.ModuleCode = txtModuleCode.Value;
                newModule.LecturerID = lecturerID;
                newModule.Date = Convert.ToDateTime(dateSelect.Value);

                ModuleHandler moduleHandler = new ModuleHandler();

                lastID = moduleHandler.AddNewModule(newModule);
                if (lastID > 0)
                {
                    litAlert.Text = "<div class='alert alert-success'>Module added</div>";

                    Response.Redirect("AddStudents.aspx?module=" + lastID);
                }
                else
                {
                    litAlert.Text = "<div class='alert alert-danger'>Failed to add module</div>";
                }

            }
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lstLecturers.Items.Clear();

            string searchQuery = txtSearch.Value.Replace(" ", "%");
            searchQuery = searchQuery.Trim();

            LecturerHandler lectuerHandler = new LecturerHandler();

            lstLecturers.DataSource = lectuerHandler.GetLecturerSearchList(searchQuery);
            lstLecturers.DataTextField = "FirstName";
            lstLecturers.DataValueField = "LecturerID";
            lstLecturers.DataBind();
        }
    }
}