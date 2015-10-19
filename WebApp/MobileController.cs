using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DAL;
using BLL;

namespace WebApp
{
    public class MobileController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            RollCallHandler rollCallHandler = new RollCallHandler();
            List<RollCall> listRollCalls = rollCallHandler.GetRollCallList(1);

            return new string[] { "value1", listRollCalls[0].Status };
        }

        //get module roll calls
        // GET api/mobile/1
        public List<TempModule> Get(string lecturer)
        {
            int lecturerID = Convert.ToInt32(lecturer);

            //generate a table to list all modules
            ModuleHandler moduleHandler = new ModuleHandler();

            List<Module> listModules = moduleHandler.GetModuleList(lecturerID);
            List<TempModule> newTempModules = new List<TempModule>();
            TempModule tempModule;
            //add modules to table as it is generated
            for (int i = 0; i < listModules.Count; i++)
            {
                tempModule = new TempModule();
                tempModule.ModuleID = listModules[i].ModuleID;
                tempModule.ModuleCode = listModules[i].ModuleCode;
                newTempModules.Add(tempModule);
                //moduleID = listModules[i].ModuleID;
                //htmlOutput += "<tr><td>" + listModules[i].ModuleCode + "</td><td>" + listModules[i].Date.ToString("MM / yyyy") + " </td><td><a href=\"ViewStudents.aspx?module=" + listModules[i].ModuleID + "\">View</a></td><td><a href=\"DisableModule.aspx?id=" + listModules[i].ModuleID + "\"/>Disable</a></td></tr>\n";
            }

            return newTempModules;
        }


        //lecturer log in
        //get /api/mobile/a@a/123
        public int Get(string email, string password)
        {
            //log in here
            int lecturerId = 0;
            LecturerHandler lecturerHandler = new LecturerHandler();
            Lecturer lecturer = new Lecturer();

            lecturer = lecturerHandler.ValidateLogin(email, password);
            try
            {
                lecturerId = lecturer.LecturerID;
            }
            catch (Exception)
            {

            }
            return lecturerId;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    public class TempModule
    {
        public int ModuleID { get; set; }
        public string ModuleCode { get; set; }
    }
}