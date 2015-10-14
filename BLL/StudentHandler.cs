using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;

namespace BLL
{
    public class StudentHandler
    {
        StudentDBAccess studentDB = null;

        public StudentHandler()
        {
            studentDB = new StudentDBAccess();
        }

        public bool AddNewStudent(Student student)
        {
            return studentDB.AddNewStudent(student);
        }

        public Student GetStudentID(string studentNumber)
        {
            return studentDB.GetStudentID(studentNumber);
        }

        public List<Student> GetStudentList(int moduleID)
        {
            return studentDB.GetStudentList(moduleID);
        }
    }
}
