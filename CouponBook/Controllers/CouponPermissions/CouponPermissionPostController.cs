using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.CouponPermissions;
using Microsoft.AspNetCore.Mvc;
using CouponBook.Dtos;

namespace CouponBook.Controllers.CouponPermissions
{
    public class CouponPermissionPostController : ControllerBase
    {   
        public readonly ICouponPermissionService _couponPermissionService;
        public CouponPermissionPostController(ICouponPermissionService couponPermissionService){
            _couponPermissionService = couponPermissionService;
        }
            
        [HttpPost]
        [Route("api/CouponPermission/Create")]
        public async Task<IActionResult> CreatePermissionAsync([FromBody] CouponPermissionDto couponPermissionDto){
            try{
                await _couponPermissionService.CreatePermissionAsync(couponPermissionDto);
                return Ok("Coupon permission created successfully.");
            }
            catch (Exception ex) {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}