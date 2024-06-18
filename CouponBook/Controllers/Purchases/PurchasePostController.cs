// Importa los espacios de nombres necesarios para el proyecto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CouponBook.Dtos; // Importa las definiciones de DTO (Data Transfer Objects)
using CouponBook.Services.Purchases; // Importa el servicio de compras
using Microsoft.AspNetCore.Mvc; // Importa funcionalidades para controladores de MVC

namespace CouponBook.Controllers.Purchases // Define el espacio de nombres para el controlador de compras
{
    // Define un controlador API para gestionar operaciones de creación de compras
    public class PurchasePostController : ControllerBase
    {
        // Declara una propiedad solo de lectura para el servicio de compras
        public readonly IPurchaseService _purchaseService;

        // Constructor que recibe una implementación del servicio de compras y la asigna a la propiedad
        public PurchasePostController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        // Define un método de acción HTTP POST para agregar una nueva compra
        [HttpPost("api/purchases/")]
        public async Task<IActionResult> AddPurchase([FromBody] PurchaseDto purchaseDto)
        {
            try
            {
                // Verifica si los datos de la compra son nulos y retorna un resultado BadRequest (400) si lo son
                if (purchaseDto == null)
                {
                    return BadRequest("Invalid purchase data.");
                }

                // Llama al servicio para agregar la nueva compra de forma asincrónica
                var createdPurchase = await _purchaseService.AddPurchaseAsync(purchaseDto);

                // Mensaje de confirmación de registro
                var response = new
                {
                    Message = "Purchase registered successfully.",
                    Purchase = createdPurchase
                };

                // Retorna un resultado Created (201) con la respuesta y la URL de la acción
                return CreatedAtAction(nameof(AddPurchase), response);
            }
            catch (ArgumentNullException ex)
            {
                // Maneja excepciones específicas de argumento nulo y retorna un resultado BadRequest (400)
                return BadRequest($"Argument null exception: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                // Maneja excepciones específicas de operación inválida y retorna un resultado de error del servidor (500)
                return StatusCode(500, $"Invalid operation exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Maneja excepciones generales y retorna un resultado de error del servidor (500)
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}