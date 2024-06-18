using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.UpdateLogs;
using Microsoft.AspNetCore.Mvc;
using CouponBook.Dtos;

namespace CouponBook.Controllers.UpdateLogs
{
    public class UpdateLogPostController : ControllerBase
    {   
        public readonly IUpdateLogService _updateLogService;
        public UpdateLogPostController(IUpdateLogService updateLogService){
            _updateLogService = updateLogService;
        }
    
    [HttpPatch]
    [Route("api/coupon/body/{id}")]

    public async Task<IActionResult> UpdateCoupon(int id, [FromBody] CouponUpdateDto updateDto, string pcode){
        try{
            await _updateLogService.UpdateCouponAsync(id, updateDto, pcode);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new { Message = $"Coupon with id {id} not found." });
        }
        
    }

    [HttpPatch]
    [Route("api/coupon/status/{id}")]
    public async Task<IActionResult> UpdateCouponStatus(int id, [FromBody] CouponStatusUpdateDto statusDto, string pcode){
        try{
            await _updateLogService.UpdateCouponStatusAsync(id, statusDto, pcode);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new { Message = $"Coupon with id {id} not found." });
        }
        
    }
        
    }
}