using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices.IDataAccess
{
    public interface ISuppliers
    {
        string Type { get; set; }
        Nullable<int> Supplierid { get; set; }
        DataTable GetSuppliers();
    }
}
