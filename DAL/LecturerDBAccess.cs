using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LecturerDBAccess
    {
        public bool AddNewLecturer(Lecturer lecturer)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {                
			    new SqlParameter("@Email", lecturer.Email),
			    new SqlParameter("@Password", lecturer.Password),
			    new SqlParameter("@FirstName", lecturer.FirstName),
			    new SqlParameter("@Surname", lecturer.Surname),
		    };

            return DBHelper.ExecuteNonQuery("sp_AddNewLecturer", CommandType.StoredProcedure, parameters);
        }

        public Lecturer ValidateLogin(string email, string password)
        {
            Lecturer lecturer = null;

            SqlParameter[] paramaters = new SqlParameter[]
            {
                new SqlParameter("@Email", email),
                new SqlParameter("@Password", password)
            };

            using (DataTable table = DBHelper.ExecuteParamerizedSelectCommand("sp_ValidateLogin", CommandType.StoredProcedure, paramaters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    lecturer = new Lecturer();

                    lecturer.LecturerID = Convert.ToInt32(row["LecturerID"]);
                    lecturer.FirstName = row["FirstName"].ToString();
                    lecturer.Surname = row["Surname"].ToString();
                }
            }
            return lecturer;
        }

        public bool UpdateLecturerPassword(Lecturer lecturer)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Email", lecturer.Email),
                new SqlParameter("@Password", lecturer.Password)
            };
            return DBHelper.ExecuteNonQuery("sp_UpdateLecturerPassword", CommandType.StoredProcedure, parameters);
        }
        public Lecturer ValidateEmail(string email)
        {
            Lecturer lecturer = null;

            SqlParameter[] paramaters = new SqlParameter[]
            {
                new SqlParameter("@Email", email)
            };

            using (DataTable table = DBHelper.ExecuteParamerizedSelectCommand("sp_ValidateEmail", CommandType.StoredProcedure, paramaters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    lecturer = new Lecturer();

                    lecturer.Email = row["Email"].ToString();
                }
            }
            return lecturer;
        }

        public Lecturer GetLecturerDetails(int lecturerID)
        {
            Lecturer lecturer = null;

            SqlParameter[] paramaters = new SqlParameter[]
            {
                new SqlParameter("@LecturerID", lecturerID),
            };

            using (DataTable table = DBHelper.ExecuteParamerizedSelectCommand("sp_GetLecturerDetails", CommandType.StoredProcedure, paramaters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    lecturer = new Lecturer();

                    lecturer.LecturerID = Convert.ToInt32(row["LecturerID"]);
                    lecturer.FirstName = row["FirstName"].ToString();
                    lecturer.Surname = row["Surname"].ToString();
                    lecturer.Email = row["Email"].ToString();
                    lecturer.Role = Convert.ToInt32(row["Role"]);
                }
            }
            return lecturer;
        }

        public bool UpdateLecturer(Lecturer lecturer)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@LecturerID", lecturer.LecturerID),
                new SqlParameter("@FirstName", lecturer.FirstName),
                new SqlParameter("@Surname", lecturer.Surname),
                new SqlParameter("@Email", lecturer.Email),
            };
            return DBHelper.ExecuteNonQuery("sp_UpdateLecturer", CommandType.StoredProcedure, parameters);
        }

        public bool UpdateLecturerWithPassword(Lecturer lecturer)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@LecturerID", lecturer.LecturerID),
                new SqlParameter("@FirstName", lecturer.FirstName),
                new SqlParameter("@Surname", lecturer.Surname),
                new SqlParameter("@Email", lecturer.Email),
                new SqlParameter("@Password", lecturer.Password),
            };
            return DBHelper.ExecuteNonQuery("sp_UpdateLecturerWithPassword", CommandType.StoredProcedure, parameters);
        }

        public List<Lecturer> GetLecturerSearchList(string searchQuery)
        {
            List<Lecturer> listLecturers = null;

            SqlParameter[] paramaters = new SqlParameter[]
            {
                new SqlParameter("@SearchQuery", searchQuery),
            };

            using (DataTable table = DBHelper.ExecuteParamerizedSelectCommand("sp_GetLecturerSearchList", CommandType.StoredProcedure, paramaters))
            {
                if (table.Rows.Count > 0)
                {
                    listLecturers = new List<Lecturer>();

                    foreach (DataRow row in table.Rows)
                    {
                        Lecturer lecturer = new Lecturer();
                        lecturer.LecturerID = Convert.ToInt32(row["LecturerID"]);
                        lecturer.FirstName = row["Name"].ToString();

                        listLecturers.Add(lecturer);
                    }
                }
            }

            return listLecturers;
        }
    }
}
