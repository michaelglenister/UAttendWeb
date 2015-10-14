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
    public partial class StudentDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get list of modules to select from
            int lecturerID = Convert.ToInt32(Session["LecturerID"]);
            ModuleHandler moduleHandler = new ModuleHandler();
            
            if (!Page.IsPostBack)
            {
                dlModules.DataSource = moduleHandler.GetModuleList(lecturerID);
                dlModules.DataTextField = "ModuleCode";
                dlModules.DataValueField = "ModuleID";
                dlModules.DataBind();

                dlModules_SelectedIndexChanged(null, null);
            }
        }

        protected void btnGetReport_Click(object sender, EventArgs e)
        {
            string htmlOutput = "<tr><th>Date</th><th>Status</th></tr>";
            litReport.Text = "";
            //for each roll call held show status of selected student

            RollCallHandler rollCallHandler = new RollCallHandler();
            //get list of roll calls held for the module
            List<RollCall> listRollCalls = rollCallHandler.GetRollCallList(Convert.ToInt32(dlModules.SelectedValue));

            //get a students attendance for each of the found roll calls
            Student_RollCall student_RollCall = new Student_RollCall();
            Student_RollCallHandler student_RollCallHandler = new Student_RollCallHandler();
            
            foreach (RollCall r in listRollCalls)
            {
                student_RollCall = student_RollCallHandler.GetStudentAttendance(r.RollCallID, Convert.ToInt32(dlStudents.SelectedValue));

                try
                {

                    litReport.Text += student_RollCall.Status + "<br/>";
                    DateTime date = Convert.ToDateTime(r.TimeOfRollCall);
                    htmlOutput +=  "<tr><td>" + date.ToString("MM/dd/yyyy HH:mm tt") + "</td><td>" + student_RollCall.Status + "</td></tr>\n";
                }
                catch (NullReferenceException ex)
                {
                    litReport.Text += "Absent<br/>";
                    DateTime date = Convert.ToDateTime(r.TimeOfRollCall);
                    htmlOutput += "<tr><td>" + date.ToString("MM/dd/yyyy HH:mm tt") + "</td><td>absent</td></tr>\n";
                }
            }

            Student student = new Student();
            StudentHandler studentHandler = new StudentHandler();

            litReport.Text = htmlOutput;


        }

        protected void dlModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get students from selected module
            StudentHandler studentHandler = new StudentHandler();

            List<Student> listStudents = studentHandler.GetStudentList(Convert.ToInt32(dlModules.SelectedValue));

            if (listStudents == null)
            {
                dlStudents.Items.Clear();
                dlStudents.Items.Add("No students");
            }
            else
            {
                dlStudents.DataSource = listStudents;
                dlStudents.DataTextField = "StudentNumber";
                dlStudents.DataValueField = "StudentID";
                dlStudents.DataBind();
            }
        }
    }
}