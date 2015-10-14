using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BusinessDBAccess
    {
        public Business GetBusinessDetails()
        {
            Business business = null;

            using (DataTable table = DBHelper.ExecuteSelectCommand("sp_GetBusinessDetails", CommandType.StoredProcedure))
            {
                if (table.Rows.Count >= 1)
                {
                    DataRow row = table.Rows[0];
                    business = new Business();

                    business.BusinessID = Convert.ToInt32(row["BusinessID"]);
                    business.Name = row["Name"].ToString();
                    business.Email = row["Email"].ToString();
                    business.EmailPassword = row["EmailPassword"].ToString();
                    business.EmailServer = row["EmailServer"].ToString();
                    business.EmailPort = Convert.ToInt32(row["EmailPort"]);
                }
            }
            return business;
        }
    }
}
