using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class StudentDBAccess
    {
        public bool AddNewStudent(Student student)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {                
			    new SqlParameter("@StudentNumber", student.StudentNumber),
			    new SqlParameter("@FirstName", student.FirstName),
                new SqlParameter("@Surname", student.Surname),
                new SqlParameter("@ModuleID", student.ModuleID)
		    };

            return DBHelper.ExecuteNonQuery("sp_AddNewStudent", CommandType.StoredProcedure, parameters);
        }

        public Student GetStudentID(string studentNumber)
        {
            Student student = null;

            SqlParameter[] paramaters = new SqlParameter[]
            {
                new SqlParameter("@StudentNumber", studentNumber),
            };

            using (DataTable table = DBHelper.ExecuteParamerizedSelectCommand("sp_GetStudentID", CommandType.StoredProcedure, paramaters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    student = new Student();

                    student.StudentID = Convert.ToInt32(row["StudentID"]);
                    student.StudentNumber = row["StudentNumber"].ToString();
                    student.FirstName = row["FirstName"].ToString();
                    student.Surname = row["Surname"].ToString();
                    //student.ModuleID = Convert.ToInt32(row["ModuleID"]);
                    student.TagID = row["TagID"].ToString();
                }
            }
            return student;
        }

        public List<Student> GetStudentList(int moduleID)
        {
            //gets list of students linked to a module

            List<Student> listStudents = null;

            SqlParameter[] paramaters = new SqlParameter[]
            {
                new SqlParameter("@ModuleID", moduleID),
            };

            using (DataTable table = DBHelper.ExecuteParamerizedSelectCommand("sp_GetStudentList", CommandType.StoredProcedure, paramaters))
            {
                if (table.Rows.Count > 0)
                {
                    listStudents = new List<Student>();

                    foreach (DataRow row in table.Rows)
                    {
                        Student student = new Student();
                        student.StudentID = Convert.ToInt32(row["StudentID"]);
                        student.StudentNumber = row["StudentNumber"].ToString();
                        student.FirstName = row["FirstName"].ToString();
                        student.Surname = row["Surname"].ToString();
                        //student.TagID = Convert.ToDateTime(row["TagID"]);
                        listStudents.Add(student);
                    }
                }
            }

            return listStudents;
        }
    }
}
