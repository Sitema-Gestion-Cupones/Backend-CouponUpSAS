using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Coupons;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Coupons
{
    public class CouponGetController : ControllerBase
    {   
        public readonly ICouponService _couponService;
        public CouponGetController(ICouponService couponService){
            _couponService = couponService;
        }
        
    }
}