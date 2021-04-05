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
    public class Suppliers : ISuppliers
    {
        private readonly ISqlRepository _Sqlrepository;

        public Suppliers(ISqlRepository sqlrepository)
        {
            _Sqlrepository = sqlrepository;

        }

        public string Type { get ; set ; }
        public Nullable<int> Supplierid { get; set; }

        public DataTable GetSuppliers()
        {
            SqlParameter[] parameters = {
            new SqlParameter(){ParameterName="@Type", SqlDbType=SqlDbType.VarChar, Value=this.Type},
            new SqlParameter(){ParameterName="@SupplierID", SqlDbType=SqlDbType.Int, Value=this.Supplierid}
            };
            return _Sqlrepository.ExecuteSPDataTable("SP_Supplier", parameters);

        }

        
    }
}
