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
    public partial class StudentAverage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //display list of modules linked to the lecturer to select from
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

        protected void btnGetReport_Click(object sender, EventArgs e)
        {
            //when a module us selected display all students linked to that module, and their attendance for each roll call
            //data needed: student name, status

            //get studentID, firstname, surname using ModuleID
            //for each student use studentID to find roll call status
            
            StudentHandler studentHandler = new StudentHandler();
            RollCallHandler rollCallHandler = new RollCallHandler();
            Student_RollCallHandler student_RollCallHandler = new Student_RollCallHandler();
            Student_RollCall student_RollCall = new Student_RollCall();

            List<Student> listStudents = studentHandler.GetStudentList(Convert.ToInt32(dlModules.SelectedValue));

            litReport.Text = "";
            string htmlOutput = "<tr><th>Student</th><th>Percent</th></tr>";

            //get list of roll calls IDs held for a module
            List<RollCall> listRollCalls = rollCallHandler.GetRollCallList(Convert.ToInt32(dlModules.SelectedValue));

            int countRollCall = 0;
            int countStudent = 0;
            string[,] studentData = new string[listStudents.Count, 2];

            string[] student = new string[listStudents.Count] ;
            int[] attending = new int[listRollCalls.Count];
            int temp = 0;

            for (int i = 0; i < listStudents.Count; i++)
            {
                studentData[i, 1] = "0";
            }

            foreach (Student s in listStudents)
            {
                student[countStudent] = s.FirstName + " " + s.Surname;
                studentData[countStudent, 0] = s.FirstName + " " + s.Surname + " " + s.StudentNumber;

                //now get this students attendance records, one for each roll call, if no record exists assume absent
                foreach (RollCall r in listRollCalls)
	            {
                    student_RollCall = student_RollCallHandler.GetStudentAttendance(r.RollCallID, s.StudentID);
                    try
                    {
                        litReport.Text += s.FirstName + "&nbsp" + student_RollCall.Status;
                        
                        attending[countRollCall] += 1;

                        temp = Convert.ToInt32(studentData[countStudent, 1]);
                        temp += 1;
                        studentData[countStudent, 1] = temp.ToString();
                    }
                    catch (NullReferenceException ex)
                    {
                        litReport.Text += s.FirstName + "&nbsp" + "absent";

                        attending[countRollCall] += 0;

                        temp = Convert.ToInt32(studentData[countStudent, 1]);
                        temp += 0;
                        studentData[countStudent, 1] = temp.ToString();
                    }
                    countRollCall++;
                }

                countStudent++;
                countRollCall = 0;

                litReport.Text += "</br></br>";
                
            }

            litReport.Text = "";

            for (int i = 0; i < listStudents.Count; i++)
            {
                studentData[i, 1] = (Convert.ToDouble(studentData[i, 1]) / listRollCalls.Count * 100).ToString();
                studentData[i, 1] = Math.Round(Convert.ToDouble(studentData[i, 1]), 0).ToString();

                htmlOutput += "<tr><td>" + studentData[i, 0] + "</td><td>" + studentData[i, 1] + "</td></tr>\n";
                litReport.Text += studentData[i, 0] + " " + studentData[i, 1] + "</br>";
            }

            litReport.Text = htmlOutput;

        }
    }
}