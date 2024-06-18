// Importa los espacios de nombres necesarios para el proyecto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Models; // Importa los modelos de datos

namespace CouponBook.Repository.Redemptions // Define el espacio de nombres para el repositorio de redenciones
{
    // Define la interfaz del repositorio para gestionar las operaciones de redenciones
    public interface IRedemptionRepository
    {
        // Define un método asincrónico para añadir una redención
        Task<Redemption> AddRedemptionAsync(Redemption redemption);

        // Define un método asincrónico para obtener una redención por su ID
        Task<Redemption> GetRedemptionByIdAsync(int id);

        // Define un método asincrónico para obtener todas las redenciones
        Task<IEnumerable<Redemption>> GetAllRedemptionsAsync();

        // Define un método asincrónico para obtener redenciones por fecha
        Task<IEnumerable<Redemption>> GetRedemptionsByDateAsync(DateTime date);
    }
}
