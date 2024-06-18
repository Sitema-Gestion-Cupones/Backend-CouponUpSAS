using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Coupons;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Coupons
{
    public class CouponPutController : ControllerBase
    {   
        public readonly ICouponService _couponService;
        public CouponPutController(ICouponService couponService){
            _couponService = couponService;
        }
        
    }
}