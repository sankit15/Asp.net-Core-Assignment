using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class SupplierRate
    {
       public int SupplierID { get; set; }
        public int Rate { get; set; }
    }

    public class GetAsyncSupplier
    {
        public IList<SupplierRate> GetAsync { get; set; }
        public IList<SupplierRate> GetApi  { get; set; }
    }
 
}
