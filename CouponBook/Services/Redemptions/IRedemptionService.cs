// Importa los espacios de nombres necesarios para el proyecto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Dtos; // Importa los DTOs para redenciones

namespace CouponBook.Services.Redemptions // Define el espacio de nombres para el servicio de redenciones
{
    // Define la interfaz del servicio para gestionar operaciones de redenciones
    public interface IRedemptionService
    {
        // Define un método asincrónico para crear una nueva redención
        Task<RedemptionCreateDto> CreateRedemptionAsync(RedemptionCreateDto redemptionDto);

        // Define un método asincrónico para obtener una redención por su ID
        Task<RedemptionIdDto> GetRedemptionByIdAsync(int id);

        // Define un método asincrónico para obtener todas las redenciones
        Task<IEnumerable<RedemptionIdDto>> GetAllRedemptionsAsync();

        // Define un método asincrónico para obtener redenciones por fecha
        Task<IEnumerable<RedemptiondateDto>> GetRedemptionsByDateAsync(DateTime date);
    }
}
