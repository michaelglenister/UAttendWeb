using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Student_RollCallDBAccess
    {
        public bool AddNewStudent_RollCall(Student_RollCall student_RollCall)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {                
			    new SqlParameter("@StudentID", student_RollCall.StudentID),
                new SqlParameter("@RollCallID", student_RollCall.RollCallID),
                new SqlParameter("@Status", student_RollCall.Status),
                new SqlParameter("@TimeOfSignIn", student_RollCall.TimeOfSignIn)
		    };

            return DBHelper.ExecuteNonQuery("sp_AddNewStudent_RollCall", CommandType.StoredProcedure, parameters);
        }

        public List<string> GetModuleAttendanceList(int ModuleID)
        {
            SqlParameter[] paramaters = new SqlParameter[]
            {
                new SqlParameter("@ModuleID", ModuleID)
            };

            List<string> results = null;
            string[] rollCall = new string[4];

            using (DataTable table = DBHelper.ExecuteParamerizedSelectCommand("sp_GetModuleAttendanceList", CommandType.StoredProcedure, paramaters))
            {
                if (table.Rows.Count > 0)
                {
                    results = new List<string>();

                    foreach (DataRow row in table.Rows)
                    {
                        rollCall[0] = row["RollCallID"].ToString();
                        rollCall[1] = row["TimeOfRollCall"].ToString();
                        rollCall[2] = row["Column1"].ToString();
                        rollCall[3] = row["Column2"].ToString();

                        results.AddRange(rollCall);
                        
                    }
                }
            }
            return results;
        }

        public Student_RollCall GetStudentAttendance(int rollCallID, int studentID)
        {
            SqlParameter[] paramaters = new SqlParameter[]
            {
                new SqlParameter("@rollCallID", rollCallID),
                new SqlParameter("@studentID", studentID)
            };

            Student_RollCall student_RollCall = null;

            using (DataTable table = DBHelper.ExecuteParamerizedSelectCommand("sp_GetStudentAttendance", CommandType.StoredProcedure, paramaters))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        student_RollCall = new Student_RollCall();
                        student_RollCall.StudentID = Convert.ToInt32(row["StudentID"]);
                        student_RollCall.RollCallID = Convert.ToInt32(row["RollCallID"]);
                        student_RollCall.Status = row["Status"].ToString();
                        student_RollCall.TimeOfSignIn = row["TimeOfSignIn"].ToString();
                    }
                }
            }
            return student_RollCall;
        }

        public Student_RollCall GetDetailedAttendance(int moduleID, int studentID)
        {
            //broken and unused
            SqlParameter[] paramaters = new SqlParameter[]
            {
                new SqlParameter("@moduleID", moduleID),
                new SqlParameter("@studentID", studentID)
            };

            Student_RollCall student_RollCall = null;

            using (DataTable table = DBHelper.ExecuteParamerizedSelectCommand("sp_GetDetailedAttendance", CommandType.StoredProcedure, paramaters))
            {
                if (table.Rows.Count > 0)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        student_RollCall = new Student_RollCall();
                        student_RollCall.StudentID = Convert.ToInt32(row["StudentID"]);
                        student_RollCall.RollCallID = Convert.ToInt32(row["RollCallID"]);
                        student_RollCall.Status = row["Status"].ToString();
                        student_RollCall.TimeOfSignIn = row["TimeOfSignIn"].ToString();
                    }
                }
            }
            return student_RollCall;
        }
    }
}
