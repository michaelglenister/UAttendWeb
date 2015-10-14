using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using BLL;
using DAL;
using System.Web.UI.DataVisualization.Charting;

namespace WebApp
{
    public partial class SubjectAverage : System.Web.UI.Page
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

        protected void btnGetReport_Click(object sender, EventArgs e)
        {
            
            string chartHead = "<script>new Morris.Line({element: 'mychart',;data: [";
            string chartFoot = "],xkey: 'date',ykeys: ['value'],labels: ['Percentage']});</script>";
            //{ date: '1990', value: 20 },
            string chartBody = "";

            //create report showing the average attendance for a module per roll call
            Student_RollCallHandler student_RollCallHandler = new Student_RollCallHandler();

            List<string> result = student_RollCallHandler.GetModuleAttendanceList(Convert.ToInt32(dlModules.SelectedValue));

            int count = 0;
            int totalStudents = 0;
            //format of string returned is:
            //rollCallID rollCallDate totalModuleStudents totalSignedInStudents
            try
            {
                
                litReport.Text = "";
                string date = "";
                double attending = 0;

                foreach (String s in result)
                {
                    count++;

                    if (count < 4)
                    {
                        //litReport.Text += s + "&nbsp"; display data
                        if (count == 2)
                        {
                            //{ date: '1990', value: 20 },
                            date = s;
                            date = date.Substring(0, 10);
                            chartBody += "{ date: '" + date + ", ";
                        }
                        if (count == 3)
                        {
                            totalStudents = Convert.ToInt32(s);
                        }
                    }
                    else
                    {
                        //litReport.Text += s + "</br>"; display data
                        count = 0;
                        double attended;
                        if (Convert.ToInt32(s) == 0)
                        {
                            attended = 0;
                        }
                        else
                        {
                            attended = totalStudents / Convert.ToInt32(s);
                        }
                        attending = Convert.ToDouble(s) / Convert.ToDouble(totalStudents);
                        attending *= 100;
                        chartBody += "value: " + Math.Round(attended) + "},";

                        FillGraph(date, attending);
                    }
                }
                
                litChart.Text = chartHead + chartBody + chartFoot;
            }
            catch (NullReferenceException)
            {
                litReport.Text = "<div class='alert alert-danger'>No records found</div>";
            }

            
        }

        private void FillGraph(string x, double y)
        {
            
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.Series["Series1"].Points.AddXY(x, y);
        }
    }
}