// Importa los espacios de nombres necesarios para el proyecto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Redemptions; // Importa el servicio de redenciones
using Microsoft.AspNetCore.Mvc; // Importa funcionalidades para controladores de MVC

namespace CouponBook.Controllers.Redemptions // Define el espacio de nombres para el controlador de redenciones
{
    // Define un controlador API para gestionar operaciones de obtención de redenciones
    public class RedemptionGetController : ControllerBase
    {   
        // Declara una propiedad solo de lectura para el servicio de redenciones
        public readonly IRedemptionService _redemptionService;

        // Constructor que recibe una implementación del servicio de redenciones y la asigna a la propiedad
        public RedemptionGetController(IRedemptionService redemptionService)
        {
            _redemptionService = redemptionService;
        }

        // Define un método de acción HTTP GET para obtener una redención por su ID
        [HttpGet("api/redemptions/id")]
        public async Task<IActionResult> GetRedemptionById(int id)
        {
            try
            {
                // Llama al servicio para obtener la redención por ID de forma asincrónica
                var redemption = await _redemptionService.GetRedemptionByIdAsync(id);
                
                // Si la redención no se encuentra, retorna un resultado NotFound (404)
                if (redemption == null)
                {
                    return NotFound($"Redemption with ID {id} not found.");
                }
                
                // Si la redención se encuentra, retorna un resultado OK (200) con la redención
                return Ok(redemption);
            }
            catch (ArgumentException ex)
            {
                // Manejo específico para errores de argumentos inválidos
                return BadRequest($"Invalid argument: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejo general de excepciones
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        } 
        
        // Define un método de acción HTTP GET para obtener todas las redenciones
        [HttpGet("api/redemptions/")]
        public async Task<IActionResult> GetAllRedemptions()
        {
            try
            {
                // Llama al servicio para obtener todas las redenciones de forma asincrónica
                var redemptions = await _redemptionService.GetAllRedemptionsAsync();
                
                // Retorna un resultado OK (200) con la lista de todas las redenciones
                return Ok(redemptions);
            }
            catch (Exception ex)
            {
                // Manejo general de excepciones
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }

        // Define un método de acción HTTP GET para obtener redenciones por fecha
        [HttpGet("api/redemptions/{date}")]
        public async Task<IActionResult> GetRedemptionsByDate(DateTime date)
        {
            try
            {
                // Llama al servicio para obtener las redenciones por fecha de forma asincrónica
                var redemptions = await _redemptionService.GetRedemptionsByDateAsync(date);
                
                // Si no se encuentran redenciones o la lista está vacía, retorna un resultado NotFound (404)
                if (redemptions == null || !redemptions.Any())
                {
                    return NotFound($"No redemptions found for the date {date.ToShortDateString()}.");
                }
                
                // Si se encuentran redenciones, retorna un resultado OK (200) con la lista de redenciones
                return Ok(redemptions);
            }
            catch (FormatException ex)
            {
                // Manejo específico para errores de formato de fecha
                return BadRequest($"Invalid date format: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejo general de excepciones
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
