using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Dtos;
using CouponBook.Services.Coupons;
using Microsoft.AspNetCore.Mvc;
using CouponBook.Repository.Coupons;

namespace CouponBook.Controllers.Coupons
{
    public class CouponPostController : ControllerBase
    {   
        public readonly ICouponRepository _couponRepository;
        public CouponPostController(ICouponRepository couponRepository){
            _couponRepository = couponRepository;
        }

        [HttpPost]
        [Route("/coupons")]
        public async Task<IActionResult> Createcupon(CouponDto coupon)
        {
            if (coupon == null || string.IsNullOrEmpty(coupon.Code))
            {
                return BadRequest(new { Message = "El cupon es requerido" });
            }
            try
            {
                await _couponRepository.AddCoupon(coupon);
                return Ok(new{message = "Cupon Creado exitosamente"});
            }
            catch (ArgumentException ex)
            {
               return BadRequest($"A Ocurrido un problema {ex.Message}");
            }
        }
        
    }
}