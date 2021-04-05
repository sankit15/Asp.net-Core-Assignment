using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace IServices.IDataAccess
{
    public interface IConnection
    {
        SqlConnection Open();
        SqlConnection Close();
    }
}
