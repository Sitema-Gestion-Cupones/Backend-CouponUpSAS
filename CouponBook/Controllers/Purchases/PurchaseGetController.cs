// Importa los espacios de nombres necesarios para el proyecto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Purchases; // Importa el servicio de compras
using Microsoft.AspNetCore.Mvc; // Importa funcionalidades para controladores de MVC

namespace CouponBook.Controllers.Purchases // Define el espacio de nombres para el controlador de compras
{
    // Define un controlador API para gestionar operaciones de obtención de compras
    public class PurchaseGetController : ControllerBase
    {
        // Declara una propiedad solo de lectura para el servicio de compras
        public readonly IPurchaseService _purchaseService;

        // Constructor que recibe una implementación del servicio de compras y la asigna a la propiedad
        public PurchaseGetController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        // Define un método de acción HTTP GET para obtener una compra por su ID
        [HttpGet("api/purchases/{id}")]
        public async Task<IActionResult> GetPurchaseById(int id)
        {
            // Llama al servicio para obtener la compra por ID de forma asincrónica
            var purchase = await _purchaseService.GetPurchaseByIdAsync(id);
            
            // Si la compra no se encuentra, retorna un resultado NotFound (404)
            if (purchase == null)
            {
                return NotFound();
            }
            
            // Si la compra se encuentra, retorna un resultado OK (200) con la compra
            return Ok(purchase);
        }

        // Define un método de acción HTTP GET para obtener todas las compras
        [HttpGet("api/purchases/")]
        public async Task<IActionResult> GetAllPurchases()
        {
            // Llama al servicio para obtener todas las compras de forma asincrónica
            var purchases = await _purchaseService.GetAllPurchasesAsync();
            
            // Retorna un resultado OK (200) con la lista de todas las compras
            return Ok(purchases);
        }
    }
}