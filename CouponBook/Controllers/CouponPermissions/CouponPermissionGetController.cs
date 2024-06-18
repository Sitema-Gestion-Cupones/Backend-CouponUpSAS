using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.CouponPermissions;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.CouponPermissions
{
    public class CouponPermissionGetController : ControllerBase
    {   
        public readonly ICouponPermissionService _couponPermissionService;
        public CouponPermissionGetController(ICouponPermissionService couponPermissionService){
            _couponPermissionService = couponPermissionService;
        }

        [HttpGet]
        [Route("api/permissions/date")]
        public async Task<IActionResult> GetPermissionsByRequestDateAsync([FromQuery] DateTime requestDate){
            try{
                var permissions = await _couponPermissionService.GetPermissionsByRequestDateAsync(requestDate);
                return Ok(permissions);
            }
            catch (Exception ex){
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet()]
        [Route("api/permissionsByUser/{userId}")]
        public async Task<IActionResult> GetPermissionsByUserId(int userId){
            try{
                var permissions = await _couponPermissionService.GetPermissionsByUserIdAsync(userId);
                return Ok(permissions);
            }
            catch (Exception ex){
                return StatusCode(500, $"Error al obtener los permisos del usuario con ID {userId}: {ex.Message}");
            }
        }
        
    }
}