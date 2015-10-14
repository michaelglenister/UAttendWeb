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
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(string id)
        {
            return "1" + id;
        }

        //get /api/mobile/a @a/123
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
}