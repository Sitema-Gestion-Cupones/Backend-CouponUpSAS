using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Facturas;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Facturas
{
    public class FacturaController : ControllerBase
    {
        public readonly IFacturaServices _facturaServices;

        public FacturaController(IFacturaServices facturaServices)
        {
            _facturaServices = facturaServices;
        }
        
    }
}