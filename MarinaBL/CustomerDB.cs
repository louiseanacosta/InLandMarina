using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MarinaDL;

namespace MarinaBL
{
    public static class CustomerDB
    {
        public static Customer GetCustomer(string FirstName, string LastName)
        {
            Customer customer = new Customer();
            MarinaDB dbo = MarinaDB.Instance;

            // connect
            dbo.ConnectionString = @"server=.\sqlexpress;database=Marina;trusted_connection=true";
            dbo.SetProvider("System.Data.SqlClient");

            // work with parameters
            var firstNamePar = dbo.Create;
            firstNamePar.ParameterName = "@FirstName";
            firstNamePar.DbType = System.Data.DbType.String;
            firstNamePar.Value = FirstName;

            var lastNamePar = dbo.Create;
            lastNamePar.ParameterName = "@LastName";
            lastNamePar.DbType = System.Data.DbType.String;
            lastNamePar.Value = LastName;

            var pars = new IDataParameter[] { firstNamePar, lastNamePar};

            using (IDataReader dr = dbo.Query("SELECT ID, FirstName, LastName, Phone, City FROM Customer WHERE FirstName = @FirstName AND LastName = @LastName", CommandType.Text, pars))
            {
                while (dr.Read())
                {
                    customer = new Customer
                    {
                        Id = (int)dr["ID"],
                        FirstName = (string)dr["FirstName"],
                        LastName = (string)dr["LastName"],
                        Phone = (string)dr["Phone"],
                        City = (string)dr["City"]
                    };
                }
            }
            return customer;
        }

        public static bool SaveCustomer(Customer customer)
        {
            MarinaDB dbo = MarinaDB.Instance;
            // get the connection and provider name string
            dbo.ConnectionString = @"server=.\sqlexpress;database=Marina;trusted_connection=true";
            dbo.SetProvider("System.Data.SqlClient");

            // construct the sql text
            var sqlInsert = "INSERT INTO Customer (FirstName,LastName,Phone,City) VALUES(@FirstName,@LastName,@Phone,@City)";
            var sqlUpdate = "UPDATE Customer SET Phone = @Phone,City = @City WHERE FirstName = @FirstName AND LastName = @LastName";

            // work with parameters
            var firstNamePar = dbo.Create;
            firstNamePar.ParameterName = "@FirstName";
            firstNamePar.DbType = System.Data.DbType.String;
            firstNamePar.Value = customer.FirstName;

            var lastNamePar = dbo.Create;
            lastNamePar.ParameterName = "@LastName";
            lastNamePar.DbType = System.Data.DbType.String;
            lastNamePar.Value = customer.LastName;

            var phonePar = dbo.Create;
            phonePar.ParameterName = "@Phone";
            phonePar.DbType = System.Data.DbType.String;
            phonePar.Value = customer.Phone;

            var cityPar = dbo.Create;
            cityPar.ParameterName = "@City";
            cityPar.DbType = System.Data.DbType.String;
            cityPar.Value = customer.City;

            //initialize idata parameter array
            var pars = new IDataParameter[] { firstNamePar, lastNamePar, phonePar, cityPar };

            // try updating
            var result = dbo.Query(sqlUpdate, CommandType.Text, pars);

            // check if updated
            if(result.RecordsAffected > 0)
            {
                // all good
                return true;
            }

            dbo = MarinaDB.Instance;
            // get the connection and provider name string
            dbo.ConnectionString = @"server=.\sqlexpress;database=Marina;trusted_connection=true";
            dbo.SetProvider("System.Data.SqlClient");

            // work with parameters
            firstNamePar = dbo.Create;
            firstNamePar.ParameterName = "@FirstName";
            firstNamePar.DbType = System.Data.DbType.String;
            firstNamePar.Value = customer.FirstName;

            lastNamePar = dbo.Create;
            lastNamePar.ParameterName = "@LastName";
            lastNamePar.DbType = System.Data.DbType.String;
            lastNamePar.Value = customer.LastName;

            phonePar = dbo.Create;
            phonePar.ParameterName = "@Phone";
            phonePar.DbType = System.Data.DbType.String;
            phonePar.Value = customer.Phone;

            cityPar = dbo.Create;
            cityPar.ParameterName = "@City";
            cityPar.DbType = System.Data.DbType.String;
            cityPar.Value = customer.City;

            //initialize idata parameter array
            pars = new IDataParameter[] { firstNamePar, lastNamePar, phonePar, cityPar };

            // try inserting
            var resultInsert = dbo.Query(sqlInsert, CommandType.Text, pars);

            // check if inserted
            if(resultInsert.RecordsAffected == 1)
            {
                return true;
            }

            // save failed
            return false;

        }

    }
}
