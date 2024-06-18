// Importa los espacios de nombres necesarios para el proyecto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Dtos; // Importa las definiciones de los DTOs
using CouponBook.Services.Redemptions; // Importa el servicio de redenciones
using Microsoft.AspNetCore.Mvc; // Importa funcionalidades para controladores de MVC

namespace CouponBook.Controllers.Redemptions // Define el espacio de nombres para el controlador de redenciones
{
    // Define un controlador API para gestionar operaciones de creación de redenciones
    public class RedemptionPostController : ControllerBase
    {   
        // Declara una propiedad solo de lectura para el servicio de redenciones
        public readonly IRedemptionService _redemptionService;

        // Constructor que recibe una implementación del servicio de redenciones y la asigna a la propiedad
        public RedemptionPostController(IRedemptionService redemptionService)
        {
            _redemptionService = redemptionService;
        }

        // Define un método de acción HTTP POST para crear una nueva redención
        [HttpPost]
        [Route("api/redemptions/create")]
        public async Task<IActionResult> RedeemCoupon(int couponId, int customerUserId, int purchaseId){
            try{
                await _redemptionService.RedeemCouponAsync(couponId, customerUserId, purchaseId);
                return Ok("Cupón redimido correctamente");
            }
            catch (Exception ex){
                return StatusCode(500, $"Error al redimir el cupón: {ex.Message}");
            }
        }
    }
}

