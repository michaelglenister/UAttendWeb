using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;

namespace BLL
{
    public class Student_RollCallHandler
    {
        Student_RollCallDBAccess student_RollCallDB = null;

        public Student_RollCallHandler()
        {
            student_RollCallDB = new Student_RollCallDBAccess();
        }

        public bool AddNewRollCall(Student_RollCall student_RollCall)
        {
            return student_RollCallDB.AddNewStudent_RollCall(student_RollCall);
        }

        public List<string> GetModuleAttendanceList(int moduleID)
        {
            return student_RollCallDB.GetModuleAttendanceList(moduleID);
        }

        public Student_RollCall GetStudentAttendance(int rollCallID, int studentID)
        {
            return student_RollCallDB.GetStudentAttendance(rollCallID, studentID);
        }

        public Student_RollCall GetDetailedAttendance(int moduleID, int studentID)
        {
            //broken and unused
            return student_RollCallDB.GetDetailedAttendance(moduleID, studentID);
        }
    }
}
