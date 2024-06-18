// Importa los espacios de nombres necesarios para el proyecto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Dtos; // Importa las definiciones de los DTOs

namespace CouponBook.Services.Purchases // Define el espacio de nombres para el servicio de compras
{
    // Define una interfaz para el servicio de compras
    public interface IPurchaseService
    {
        // Define un método asincrónico para agregar una nueva compra y retorna un DTO de compra
        Task<PurchaseDto> AddPurchaseAsync(PurchaseDto purchaseDto);
        
        // Define un método asincrónico para obtener una compra por su ID y retorna un DTO con ID
        Task<PurchaseDtoId> GetPurchaseByIdAsync(int id);
        
        // Define un método asincrónico para obtener todas las compras y retorna una lista de DTOs con ID
        Task<IEnumerable<PurchaseDtoId>> GetAllPurchasesAsync();
    }
}