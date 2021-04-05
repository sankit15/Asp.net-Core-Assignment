using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.IDataAccess
{
    public interface ISqlRepository
    {
        DataTable ExecuteSPDataTable(string procedureName, SqlParameter[] parameters);
    }
}
