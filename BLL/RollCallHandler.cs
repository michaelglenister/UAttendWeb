using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;

namespace BLL
{
    public class RollCallHandler
    {
        RollCallDBAccess rollCallDB = null;

        public RollCallHandler()
        {
            rollCallDB = new RollCallDBAccess();
        }

        public int AddNewRollCall(RollCall rollCall)
        {
            return rollCallDB.AddNewRollCall(rollCall);
        }

        public bool PauseRollCall(int rollCallID)
        {
            return rollCallDB.PauseRollCall(rollCallID);
        }

        public bool ResumeRollCall(int rollCallID)
        {
            return rollCallDB.ResumeRollCall(rollCallID);
        }

        public bool EndRollCall(int rollCallID)
        {
            return rollCallDB.EndRollCall(rollCallID);
        }

        public RollCall GetRollCallDetails(int rollCallID)
        {
            return rollCallDB.GetRollCallDetails(rollCallID);
        }

        public List<RollCall> GetRollCallList(int moduleID)
        {
            return rollCallDB.GetRollCallList(moduleID);
        }

        public int SetAutoDisable(int rollCallID, string dateTime)
        {
            return rollCallDB.SetAutoDisable(rollCallID, dateTime);
        }
    }
}
