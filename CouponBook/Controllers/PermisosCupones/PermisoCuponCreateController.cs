using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.PermisosCupones;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.PermisosCupones
{
    public class PermisoCuponCreateController : ControllerBase
    {
        public readonly IPermisoCuponServices _permisoCuponServices;

        public PermisoCuponCreateController(IPermisoCuponServices permisoCuponServices)
        {
            _permisoCuponServices = permisoCuponServices;
        }
        
    }
}