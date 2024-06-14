using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Facturas;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Facturas
{
    public class FacturaDeleteController : ControllerBase
    {
        public readonly IFacturaServices _facturaServices;

        public FacturaDeleteController(IFacturaServices facturaServices)
        {
            _facturaServices = facturaServices;
        }
        
    }
}