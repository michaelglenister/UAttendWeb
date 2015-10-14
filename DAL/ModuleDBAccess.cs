using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ModuleDBAccess
    {
        public int AddNewModule(Module module)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {                
			    new SqlParameter("@ModuleCode", module.ModuleCode),
			    new SqlParameter("@LecturerID", module.LecturerID),
                new SqlParameter("@Date", module.Date)
		    };

            return DBHelper.ExecuteNonQueryGetLastID("sp_AddNewModule", CommandType.StoredProcedure, parameters);
        }

        public List<Module> GetModuleList(int lecturerID)
        {
            //gets list of enabled modules linked to a lecturer

            List<Module> listModules = null;

            SqlParameter[] paramaters = new SqlParameter[]
            {
                new SqlParameter("@LecturerID", lecturerID),
            };

            using (DataTable table = DBHelper.ExecuteParamerizedSelectCommand("sp_GetModuleList", CommandType.StoredProcedure, paramaters))
            {
                if (table.Rows.Count > 0)
                {
                    listModules = new List<Module>();

                    foreach (DataRow row in table.Rows)
                    {
                        Module module = new Module();
                        module.ModuleID = Convert.ToInt32(row["ModuleID"]);
                        module.ModuleCode = row["ModuleCode"].ToString();
                        module.LecturerID = Convert.ToInt32(row["LecturerID"]);
                        module.Date = Convert.ToDateTime(row["Date"]);
                        listModules.Add(module);
                    }
                }
            }

            return listModules;
        }

        public List<Module> GetDisabledModuleList(int lecturerID)
        {
            //gets list of disabled modules linked to a lecturer

            List<Module> listModules = null;

            SqlParameter[] paramaters = new SqlParameter[]
            {
                new SqlParameter("@LecturerID", lecturerID),
            };

            using (DataTable table = DBHelper.ExecuteParamerizedSelectCommand("sp_GetDisabledModuleList", CommandType.StoredProcedure, paramaters))
            {
                if (table.Rows.Count > 0)
                {
                    listModules = new List<Module>();

                    foreach (DataRow row in table.Rows)
                    {
                        Module module = new Module();
                        module.ModuleID = Convert.ToInt32(row["ModuleID"]);
                        module.ModuleCode = row["ModuleCode"].ToString();
                        module.LecturerID = Convert.ToInt32(row["LecturerID"]);
                        module.Date = Convert.ToDateTime(row["Date"]);
                        listModules.Add(module);
                    }
                }
            }

            return listModules;
        }

        public bool DisableModule(int moduleID)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {                
			    new SqlParameter("@ModuleID", moduleID)
		    };

            return DBHelper.ExecuteNonQuery("sp_DisableModule", CommandType.StoredProcedure, parameters);
        }

        public bool EnableModule(int moduleID)
        {
            SqlParameter[] parameters = new SqlParameter[]
		    {                
			    new SqlParameter("@ModuleID", moduleID)
		    };

            return DBHelper.ExecuteNonQuery("sp_EnableModule", CommandType.StoredProcedure, parameters);
        }

        public Module GetModuleDetails(int moduleID)
        {
            //gets list of disabled modules linked to a lecturer

            Module module = null;

            SqlParameter[] paramaters = new SqlParameter[]
            {
                new SqlParameter("@ModuleID", moduleID),
            };

            using (DataTable table = DBHelper.ExecuteParamerizedSelectCommand("sp_GetModuleDetails", CommandType.StoredProcedure, paramaters))
            {
                if (table.Rows.Count == 1)
                {
                    DataRow row = table.Rows[0];

                    module = new Module();

                    module.ModuleID = Convert.ToInt32(row["ModuleID"]);
                    module.ModuleCode = row["ModuleCode"].ToString();
                    module.LecturerID = Convert.ToInt32(row["LecturerID"]);
                    module.Date = Convert.ToDateTime(row["Date"]);
                }
            }

            return module;
        }
    }
}
