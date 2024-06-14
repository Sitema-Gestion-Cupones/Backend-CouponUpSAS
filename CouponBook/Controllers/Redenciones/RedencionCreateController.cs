using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Redenciones;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Redenciones
{
    public class RedencionCreateController : ControllerBase
    {
        public readonly IRedencionServices _redencionServices;

        public RedencionCreateController(IRedencionServices redencionServices)
        {
            _redencionServices = redencionServices;
        }
        
    }
}