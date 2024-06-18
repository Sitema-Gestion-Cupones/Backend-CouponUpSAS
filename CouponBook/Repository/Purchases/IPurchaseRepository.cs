// Importa los espacios de nombres necesarios para el proyecto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Models; // Importa las definiciones de los modelos

namespace CouponBook.Repository.Purchases // Define el espacio de nombres para el repositorio de compras
{
    // Define una interfaz para el repositorio de compras
    public interface IPurchaseRepository
    {
        // Define un método asincrónico para agregar una nueva compra
        Task<Purchase> AddPurchaseAsync(Purchase purchase);
        
        // Define un método asincrónico para obtener una compra por su ID
        Task<Purchase> GetPurchaseByIdAsync(int id);
        
        // Define un método asincrónico para obtener todas las compras
        Task<IEnumerable<Purchase>> GetAllPurchasesAsync();
    }
}