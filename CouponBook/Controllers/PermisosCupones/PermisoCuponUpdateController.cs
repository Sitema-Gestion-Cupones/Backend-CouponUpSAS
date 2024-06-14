using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.PermisosCupones;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.PermisosCupones
{
    public class PermisoCuponUpdateController : ControllerBase
    {
        public readonly IPermisoCuponServices _permisoCuponServices;

        public PermisoCuponUpdateController(IPermisoCuponServices permisoCuponServices)
        {
            _permisoCuponServices = permisoCuponServices;
        }
        
    }
}