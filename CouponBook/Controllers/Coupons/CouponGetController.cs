using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.Coupons;
using CouponBook.Services.Coupons;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Coupons
{
    public class CouponGetController : ControllerBase
    {   /*
        public readonly ICouponService _couponService;
        public CouponGetController(ICouponService couponService){
            _couponService = couponService;
        }*/

        public readonly ICouponRepository _couponRepository;
        public CouponGetController(ICouponRepository couponRepository){
            _couponRepository = couponRepository;
        }
        [HttpGet]
        [Route("/coupons")]
        public async Task<IActionResult> GetCoupons(){
            var coupons =  _couponRepository.GetAllCoupons();
            return Ok(coupons);
        }
        
    }
}