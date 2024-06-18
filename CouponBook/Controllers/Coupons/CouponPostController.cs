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
        [Route("/couponscreate")]
        public async Task<IActionResult> Createcupon(CouponCreateDto coupon)
        {
            // Validación de fechas
            /*if (coupon.ActivationDate < DateTime.Now)
            {
                return BadRequest(new { Message = "La Fecha de Activación no puede ser menor que la fecha actual" });
            }*/

            // Validación de MaxRedemptions
            if (coupon.MaxRedemptions <= 0)
            {
                return BadRequest(new { Message = "El número máximo de redenciones debe ser mayor que 0" });
            }

            // Validación de MaxRedemptionsPerUser
            if (coupon.MaxRedemptionsPerUser <= 0)
            {
                return BadRequest(new { Message = "El número máximo de redenciones por usuario debe ser mayor que 0" });
            }

           

            // Validación de DiscountType
            var validDiscountTypes = new[] { "percentage", "net" };
            if (!validDiscountTypes.Contains(coupon.DiscountType))
            {
                return BadRequest(new { Message = "El tipo de descuento debe ser 'percentage' o 'net'" });
            }

            // Validación de Category
            var validCategories = new[] { "first purchase", "seasonal or special events", "offers", "loyalty" };
            if (!validCategories.Contains(coupon.Category))
            {
                return BadRequest(new { Message = "La categoría debe ser 'first purchase', 'seasonal or special events', 'offers' o 'loyalty'" });
            }
            
            try
            {
                await _couponRepository.AddCoupon(coupon);
                return Ok(new
                {message = "Cupon Creado exitosamente",
                    Coupon = new
                    {
                        coupon.Name,
                        coupon.Code,
                        coupon.Description,
                        coupon.Category,
                        coupon.MaxRedemptions

                    }
                });
            }
            catch (ArgumentException ex)
            {
               return BadRequest($"A Ocurrido un problema {ex.Message}");
            }
        }
        
    }
}