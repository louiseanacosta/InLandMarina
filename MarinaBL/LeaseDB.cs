using MarinaDL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarinaBL
{
    public static class LeaseDB
    {
        public static List<Lease> GetLeases(string FirstName, string LastName)
        {
            List<Lease> leases = new List<Lease>();
            Lease lease = null;
            MarinaDB dbo = MarinaDB.Instance;

            Customer customer = CustomerDB.GetCustomer(FirstName, LastName);
            int CustomerID = customer.Id;

            // connect
            dbo.ConnectionString = @"server=.\sqlexpress;database=Marina;trusted_connection=true";
            dbo.SetProvider("System.Data.SqlClient");

            var customerIdPar = dbo.Create;
            customerIdPar.ParameterName = "@CustomerID";
            customerIdPar.DbType = System.Data.DbType.Int32;
            customerIdPar.Value = CustomerID;

            var pars = new IDataParameter[] { customerIdPar };

            using (IDataReader dr = dbo.Query("SELECT ID, SlipID, CustomerID FROM Lease WHERE CustomerID=@CustomerID ORDER BY SlipID", CommandType.Text, pars))
            {
                while (dr.Read())
                {
                    lease = new Lease
                    {
                        Id = dr.GetInt32(dr.GetOrdinal("ID")),
                        SlipID = dr.GetInt32(dr.GetOrdinal("SlipID")),
                        CustomerID = dr.GetInt32(dr.GetOrdinal("CustomerID"))
                    };

                    leases.Add(lease);
                }
            }
            return leases;
        }

        public static bool SaveLease(int SlipID,int CustomerID)
        {
            MarinaDB dbo = MarinaDB.Instance;
            // get the connection and provider name string
            dbo.ConnectionString = @"server=.\sqlexpress;database=Marina;trusted_connection=true";
            dbo.SetProvider("System.Data.SqlClient");

            // construct the sql text
            var sqlInsert = "INSERT INTO Lease (SlipID,CustomerID) VALUES(@SlipID,@CustomerID)";
            
            // work with parameters
            var SlipIDPar = dbo.Create;
            SlipIDPar.ParameterName = "@SlipID";
            SlipIDPar.DbType = System.Data.DbType.String;
            SlipIDPar.Value = SlipID;

            var CustomerIDPar = dbo.Create;
            CustomerIDPar.ParameterName = "@CustomerID";
            CustomerIDPar.DbType = System.Data.DbType.String;
            CustomerIDPar.Value = CustomerID;

            //initialize idata parameter array
            var pars = new IDataParameter[] { SlipIDPar, CustomerIDPar };

            // try updating
            var result = dbo.Query(sqlInsert, CommandType.Text, pars);

            // check if updated
            if (result.RecordsAffected > 0)
            {
                // all good
                return true;
            }

            return false;

        }
    }
}
