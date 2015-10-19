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
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //test url: http://localhost:7820/SignIn.aspx?id=1&num=235346
            int rollCallID = Convert.ToInt32(Request.QueryString["id"]);
            string studentNumber = Request.QueryString["num"];

            //find roll call and check if it is active
            RollCallHandler rollCallHandler = new RollCallHandler();
            RollCall rollCall = new RollCall();

            rollCall = rollCallHandler.GetRollCallDetails(rollCallID);

            //check if auto disable exists
            if (rollCall.AutoDisable != "")
            {
                DateTime autoDisableDate = DateTime.Parse(rollCall.AutoDisable);

                if (DateTime.Compare(autoDisableDate, DateTime.Now) < 0)
                {
                    //auto disabl date reached, disable roll call
                    rollCallHandler.EndRollCall(rollCallID);
                    rollCall.Status = "disabled";
                }
            }

            if (rollCall.Status == "enabled")
            {

                //get student details
                StudentHandler studentHandler = new StudentHandler();
                Student student = new Student();
                student = studentHandler.GetStudentID(studentNumber);

                //sign in
                Student_RollCallHandler student_RollCallHandler = new Student_RollCallHandler();
                Student_RollCall student_RollCall = new Student_RollCall();

                student_RollCall.RollCallID = rollCallID;
                student_RollCall.StudentID = student.StudentID;
                student_RollCall.Status = "present";
                student_RollCall.TimeOfSignIn = DateTime.Now.ToString();


                student_RollCallHandler.AddNewRollCall(student_RollCall);

            }
            else
            {

            }
        }
    }
}