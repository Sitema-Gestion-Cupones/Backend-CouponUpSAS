using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Redenciones;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Redenciones
{
    public class RedencionUpdateController : ControllerBase
    {
        public readonly IRedencionServices _redencionServices;

        public RedencionUpdateController(IRedencionServices redencionServices)
        {
            _redencionServices = redencionServices;
        }   
    }
}