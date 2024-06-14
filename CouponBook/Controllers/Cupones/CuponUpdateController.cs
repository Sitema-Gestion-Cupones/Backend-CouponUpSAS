using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Cupones;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Cupones
{
    public class CuponUpdateController : ControllerBase
    {
        public readonly ICuponServices _cuponServices;

        public CuponUpdateController(ICuponServices cuponServices)
        {
            _cuponServices = cuponServices;
        }
    }
}