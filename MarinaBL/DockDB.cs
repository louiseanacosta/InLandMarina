using MarinaDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinaBL
{
    public static class DockDB
    {
        public static List<Dock> GetDocks()
        {
            List<Dock> docks = new List<Dock>();
            Dock dock = null;
            MarinaDB dbo = MarinaDB.Instance;

            // connect
            dbo.ConnectionString = @"server=.\sqlexpress;database=Marina;trusted_connection=true";
            dbo.SetProvider("System.Data.SqlClient");

            using (IDataReader dr = dbo.Query("SELECT ID, Name FROM Dock", CommandType.Text, null))
            {
                while (dr.Read())
                {
                    dock = new Dock
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("ID")),
                        Name = (string) dr["Name"]
                    };

                    docks.Add(dock);
                }
            }
            return docks;
        }
    }
}
