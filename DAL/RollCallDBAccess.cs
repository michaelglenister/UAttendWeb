using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class RollCallDBAccess
    {
        public int AddNewRollCall(RollCall rollCall)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {                
			    new SqlParameter("@TimeOfRollCall", rollCall.TimeOfRollCall),
                new SqlParameter("@ModuleID", rollCall.ModuleID)
		    };

            return DBHelper.ExecuteNonQueryGetLastID("sp_AddNewRollCall", CommandType.StoredProcedure, parameters);
        }

        public bool PauseRollCall(int rollCallID)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {                
			    new SqlParameter("@RollCallID", rollCallID)
		    };

            return DBHelper.ExecuteNonQuery("sp_PauseRollCall", CommandType.StoredProcedure, parameters);
        }

        public bool ResumeRollCall(int rollCallID)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {                
			    new SqlParameter("@RollCallID", rollCallID)
		    };

            return DBHelper.ExecuteNonQuery("sp_ResumeRollCall", CommandType.StoredProcedure, parameters);
        }

        public bool EndRollCall(int rollCallID)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {                
			    new SqlParameter("@RollCallID", rollCallID)
		    };

            return DBHelper.ExecuteNonQuery("sp_EndRollCall", CommandType.StoredProcedure, parameters);
        }

        public RollCall GetRollCallDetails(int rollCallID)
        {
            RollCall rollCall = null;

            SqlParameter[] paramaters = new SqlParameter[]
            {
                new SqlParameter("@RollCallID", rollCallID),
            };

            using (DataTable table = DBHelper.ExecuteParamerizedSelectCommand("sp_GetRollCallDetails", CommandType.StoredProcedure, paramaters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    rollCall = new RollCall();

                    rollCall.RollCallID = Convert.ToInt32(row["RollCallID"]);
                    rollCall.TimeOfRollCall = row["TimeOfRollCall"].ToString();
                    rollCall.ModuleID = Convert.ToInt32(row["ModuleID"]);
                    rollCall.Status = row["Status"].ToString();
                    rollCall.AutoDisable = row["AutoDisable"].ToString();
                }
            }
            return rollCall;
        }

        public List<RollCall> GetRollCallList(int ModuleID)
        {
            SqlParameter[] paramaters = new SqlParameter[]
            {
                new SqlParameter("@ModuleID", ModuleID)
            };

            List<RollCall> listRollCalls = null;

            using (DataTable table = DBHelper.ExecuteParamerizedSelectCommand("sp_GetRollCallList", CommandType.StoredProcedure, paramaters))
            {
                if (table.Rows.Count > 0)
                {
                    listRollCalls = new List<RollCall>();

                    foreach (DataRow row in table.Rows)
                    {
                        RollCall rollCall = new RollCall();
                        rollCall.RollCallID = Convert.ToInt32(row["RollCallID"]);
                        rollCall.TimeOfRollCall = row["TimeOfRollCall"].ToString();
                        rollCall.ModuleID = Convert.ToInt32(row["ModuleID"]);
                        rollCall.Status = row["Status"].ToString();
                        rollCall.AutoDisable = row["AutoDisable"].ToString();

                        listRollCalls.Add(rollCall);

                    }
                }
            }
            return listRollCalls;
        }

        public int SetAutoDisable(int rollCallID, string dateTime)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@RollCallID", rollCallID),
                new SqlParameter("@AutoDisable", dateTime)
            };

            return DBHelper.ExecuteNonQueryGetLastID("sp_SetAutoDisable", CommandType.StoredProcedure, parameters);
        }
    }
}
