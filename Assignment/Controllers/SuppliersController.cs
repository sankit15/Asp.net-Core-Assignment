using IServices.IDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISuppliers _ISuppliers;
        public SuppliersController(ISuppliers iSuppliers)
        {
            _ISuppliers = iSuppliers;

        }

        [HttpGet()]
        public IActionResult SupplierRate()
        {
            _ISuppliers.Type = "AllSuppliers";
            DataTable dt= _ISuppliers.GetSuppliers();
          
            return Ok(dt);
        }

        [HttpGet("{id?}")]
        public IActionResult OverlappingSupplierRate(int? id)
        {
            _ISuppliers.Type = "OverlapSuppliers";
            _ISuppliers.Supplierid = id;
            DataTable dt = _ISuppliers.GetSuppliers();

            return Ok(dt);
        }

    }
}
