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
        [HttpPost("api/redemptions/")]
        public async Task<IActionResult> CreateRedemption([FromBody] RedemptionCreateDto redemptionDto)
        {
            try
            {
                // Verifica si el DTO de redención es nulo
                if (redemptionDto == null)
                {
                    return BadRequest("Invalid redemption data.");
                }

                // Llama al servicio para crear la redención de forma asincrónica
                var createdRedemption = await _redemptionService.CreateRedemptionAsync(redemptionDto);

                // Crea un objeto de respuesta con un mensaje de confirmación y la redención creada
                var response = new
                {
                    Message = "Redemption created successfully.",
                    Redemption = createdRedemption
                };

                // Retorna un resultado CreatedAtAction (201) con la respuesta y la URL de la acción
                return CreatedAtAction(nameof(CreateRedemption), response);
            }
            catch (ArgumentNullException ex)
            {
                // Manejo específico para argumentos nulos
                return BadRequest($"Argument null exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejo general de excepciones
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}

