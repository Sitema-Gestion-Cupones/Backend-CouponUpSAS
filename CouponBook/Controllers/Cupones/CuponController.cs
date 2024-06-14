using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Cupones;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Cupones
{
    public class CreateOwnerController : ControllerBase
    {
        public readonly ICuponServices _cuponServices;

        public CreateOwnerController(ICuponServices cuponServices)
        {
            _cuponServices = cuponServices;
        }
    }
}