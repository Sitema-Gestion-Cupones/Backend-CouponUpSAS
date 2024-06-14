using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.PermisosCupones;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.PermisosCupones
{
    public class PermisoCuponController : ControllerBase
    {
        public readonly IPermisoCuponServices _permisoCuponServices;

        public PermisoCuponController(IPermisoCuponServices permisoCuponServices)
        {
            _permisoCuponServices = permisoCuponServices;
        }
        
    }
}