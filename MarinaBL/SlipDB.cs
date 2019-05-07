using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MarinaDL;

namespace MarinaBL
{
    public static class SlipDB
    {
        public static List<Slip> GetSlips(int dockID)
        {
            List<Slip> slips = new List<Slip>();
            Slip slip = null;
            MarinaDB dbo = MarinaDB.Instance;
            string additionalWhereClause = "";

            // CHECK DEOCK ID
            if (dockID > -1) { additionalWhereClause = " AND DockID = " + dockID;  }

            // connect
            dbo.ConnectionString = @"server=.\sqlexpress;database=Marina;trusted_connection=true";
            dbo.SetProvider("System.Data.SqlClient");

            using (IDataReader dr = dbo.Query("SELECT * FROM slip WHERE id NOT IN(SELECT slipid FROM lease)" + additionalWhereClause, CommandType.Text, null))
            {
                while (dr.Read())
                {
                    slip = new Slip
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("ID")),
                        Width = dr.GetInt32(dr.GetOrdinal("Width")),
                        Length = dr.GetInt32(dr.GetOrdinal("Length")),
                        DockID = dr.GetInt32(dr.GetOrdinal("DockID"))
                    };
                    slip.Selected = true;

                    slips.Add(slip);
                }
            }
            return slips;
        }

        public static List<Slip> GetSlipsDockA()
        {
            return GetSlips(1);
        }
        public static List<Slip> GetSlipsDockB()
        {
            return GetSlips(2);
        }
        public static List<Slip> GetSlipsDockC()
        {
            return GetSlips(3);
        }


    }

}
