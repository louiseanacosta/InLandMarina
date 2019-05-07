using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;

namespace MarinaDL
{
    public class MarinaDB
    {
        DbProviderFactory Factory { get; set; }
        string ProviderName { get; set; }
        private static readonly MarinaDB _instance = new MarinaDB();
        public static MarinaDB Instance { get { return _instance; } }
        public string ConnectionString { get; set; }
        public void SetProvider(string provider)
        {
            ProviderName = provider;
            Factory = DbProviderFactories.GetFactory(provider);
        }

        public IDataParameter Create
        {
            get
            {
                return Factory.CreateParameter();
            }
        }

        // non-query method
        public void NonQuery(string sql, CommandType commandType, IDataParameter[] parameters)
        {
            if (Factory == null)
                throw new Exception("Provider name has not been set");
            try
            {
                using (var conn = Factory.CreateConnection())
                {
                    conn.ConnectionString = ConnectionString;
                    var comm = conn.CreateCommand();
                    comm.CommandText = sql;
                    comm.CommandType = commandType;
                    if (parameters != null)
                    {
                        comm.Parameters.AddRange(parameters);
                    }
                    conn.Open();

                    // execute
                    comm.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // log error
                throw new Exception("Data error occured.", ex);
            }
        }
        // query method
        public IDataReader Query(string sql, CommandType commandType, IDataParameter[] parameters)
        {
            if (Factory == null)
                throw new Exception("Provider name has not been set");

            try
            {
                // create connection
                var conn = Factory.CreateConnection();
                conn.ConnectionString = ConnectionString;

                // create command
                var comm = conn.CreateCommand();
                comm.CommandText = sql;
                comm.CommandType = commandType;
                if (parameters != null)
                {
                    comm.Parameters.AddRange(parameters);
                }
                conn.Open();


                // execute
                var reader = comm.ExecuteReader(CommandBehavior.CloseConnection); // when data reader gets closed, close connection
                return reader;
            }
            catch (Exception ex)
            {
                // log error
                throw new Exception("Data error occured.", ex);
            }
        }
    }
}
