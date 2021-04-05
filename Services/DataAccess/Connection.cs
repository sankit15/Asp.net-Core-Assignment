using IServices.IDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Services.DataAccess
{
    public class Connection : IConnection
    {
        private readonly SqlConnection cn;

        private readonly string config;
        public Connection(IAppConfigService _config)
        {
            config = _config.ConnectionString;
            cn = new SqlConnection(config);
        }

        public SqlConnection Open()
        {

            if (cn.State != ConnectionState.Open)
                cn.Open();
            return cn;
        }
        public SqlConnection Close()
        {


            if (cn.State != ConnectionState.Closed)
                cn.Close();
            return cn;
        }


    }
}
