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
    public class NfcController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/nfc/5
        public List<RollCall> Get(string module)
        {
            RollCallHandler rollCallHandler = new RollCallHandler();
            List<RollCall> listRollCalls = rollCallHandler.GetRollCallList(Convert.ToInt32(module));

            //generate a table to list all modules
            //string output = "";

            //Check to make sure there is modules in the system assigned to the lecturer
            if (listRollCalls == null)
            {

            }
            else
            {
                //output = "<tr><th>Date and time</th><th>Status</th><th>Toggle Status</th></tr>";
                //add modules to table as it is generated
                for (int i = 0; i < listRollCalls.Count; i++)
                {
                    //moduleID = listRollCalls[i].ModuleID;
                    if (listRollCalls[i].Status != "enabled")
                    {
                        listRollCalls.RemoveAt(i);
                        i--;
                        //output += "<tr><td>" + listRollCalls[i].TimeOfRollCall + "</td><td>" + listRollCalls[i].Status + " </td><td><a href=\"ToggleRollCall.aspx?id=" + listRollCalls[i].RollCallID + "\">Make Disabled</a></td></tr>\n";
                    }
                }
            }
            //litRollCallList.Text = output;

            return listRollCalls;
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