using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;

namespace BLL
{
    public class LecturerHandler
    {
        LecturerDBAccess lecturerDB = null;

        public LecturerHandler()
        {
            lecturerDB = new LecturerDBAccess();
        }

        public bool AddNewLecturer(Lecturer lecturer)
        {
            lecturer.Password = StringCipher.Encrypt(lecturer.Password, "12345uattend12345");
            return lecturerDB.AddNewLecturer(lecturer);
        }

        public Lecturer ValidateLogin(string email, string password)
        {
            string encryptedPassword = StringCipher.Encrypt(password, "12345uattend12345");
            return lecturerDB.ValidateLogin(email, encryptedPassword);
        }
        
        public Lecturer GetLecturerDetails(int lecturerID)
        {
            return lecturerDB.GetLecturerDetails(lecturerID);
        }
        
        public bool UpdateLecturer(Lecturer lecturer)
        {
            return lecturerDB.UpdateLecturer(lecturer);
        }

        public bool UpdateLecturerWithPassword(Lecturer lecturer)
        {
            lecturer.Password = StringCipher.Encrypt(lecturer.Password, "12345uattend12345");
            return lecturerDB.UpdateLecturerWithPassword(lecturer);
        }
        
        
        /*
        public List<Lecturer> GetLecturerNameList()
        {
            return lecturerDB.GetLecturerNameList();
        }
        */
        public List<Lecturer> GetLecturerSearchList(string searchQuery)
        {
            return lecturerDB.GetLecturerSearchList(searchQuery);
        }
        
        public bool ValidateEmail(string email)
        {
            Lecturer lecturer = new Lecturer();
            lecturer = lecturerDB.ValidateEmail(email);
            bool exists = false;
            try
            {
                if (lecturer.Email != null)
                    exists = true;
            }
            catch (NullReferenceException)
            {
                exists = false;
            }
            return exists;
        }

        public bool UpdateLecturerPassword(Lecturer lecturer)
        {
            lecturer.Password = StringCipher.Encrypt(lecturer.Password, "12345uattend12345");
            return lecturerDB.UpdateLecturerPassword(lecturer);
        }
    }
}
