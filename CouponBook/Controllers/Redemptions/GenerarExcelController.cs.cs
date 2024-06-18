using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Redemptions;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Redemptions
{
    public class RedemptionPutController : ControllerBase
    {   
        public readonly IRedemptionService _redemptionService;
        public RedemptionPutController(IRedemptionService redemptionService){
            _redemptionService = redemptionService;
        }
        [HttpPost]
        [Route("api/reporte/estadistica")]
        public async Task<IActionResult> GenerarExcelReporte([FromBody] string relativeFilePath){
            if (string.IsNullOrEmpty(relativeFilePath)){
                return BadRequest("agrega riuta valida.");
            }

            await _redemptionService.generarExcelAsync(relativeFilePath);
        return Ok("El reporte de Excel se ha generado exitosamente.");
        }
        
    }
}