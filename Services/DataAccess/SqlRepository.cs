using IServices.IDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess
{
   public class SqlRepository : ISqlRepository
    {
        private readonly IConnection _connection;
        public SqlRepository(IConnection connection)
        {
            _connection = connection;
        }
        public DataTable ExecuteSPDataTable(string procedureName,SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {

                cmd.CommandTimeout = 200;
                cmd.CommandText = procedureName;
                cmd.Connection = _connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parameters);
                da.SelectCommand = cmd;
                da.Fill(dt);

               
                da.Dispose();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
               
                _connection.Close();
            }
            return dt;
        }
    }
}
