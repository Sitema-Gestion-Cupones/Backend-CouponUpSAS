// Importa los espacios de nombres necesarios para el proyecto
using System.Threading.Tasks;
using AutoMapper; // Importa AutoMapper para mapeo de objetos
using CouponBook.Dtos; // Importa los DTOs para redenciones
using CouponBook.Models; // Importa los modelos de datos
using CouponBook.Repository.Redemptions; // Importa el repositorio de redenciones

namespace CouponBook.Services.Redemptions // Define el espacio de nombres para el servicio de redenciones
{
    // Implementa la interfaz IRedemptionService para gestionar operaciones de redenciones
    public class RedemptionService : IRedemptionService
    {
        // Declara una propiedad solo de lectura para el repositorio de redenciones
        private readonly IRedemptionRepository _redemptionRepository;
        // Declara una propiedad solo de lectura para el mapeo de objetos
        private readonly IMapper _mapper;

        // Constructor que recibe el repositorio y el mapeador
        public RedemptionService(IRedemptionRepository redemptionRepository, IMapper mapper)
        {
            _redemptionRepository = redemptionRepository;
            _mapper = mapper;
        }

        // Método asincrónico para crear una nueva redención
        public async Task<RedemptionCreateDto> CreateRedemptionAsync(RedemptionCreateDto redemptionDto)
        {
            // Mapea el DTO de creación de redención al modelo de redención
            var redemption = _mapper.Map<Redemption>(redemptionDto);
            // Añade la redención al repositorio
            var addedRedemption = await _redemptionRepository.AddRedemptionAsync(redemption);
            // Mapea el modelo de redención añadido al DTO de creación de redención
            return _mapper.Map<RedemptionCreateDto>(addedRedemption);
        }

        // Método asincrónico para obtener una redención por su ID
        public async Task<RedemptionIdDto> GetRedemptionByIdAsync(int id)
        {
            // Obtiene la redención del repositorio por ID
            var redemption = await _redemptionRepository.GetRedemptionByIdAsync(id);
            // Mapea el modelo de redención al DTO de redención por ID
            return _mapper.Map<RedemptionIdDto>(redemption);
        }

        // Método asincrónico para obtener todas las redenciones
        public async Task<IEnumerable<RedemptionIdDto>> GetAllRedemptionsAsync()
        {
            // Obtiene todas las redenciones del repositorio
            var redemptions = await _redemptionRepository.GetAllRedemptionsAsync();
            // Mapea los modelos de redenciones a una colección de DTOs de redención por ID
            return _mapper.Map<IEnumerable<RedemptionIdDto>>(redemptions);
        }

        // Método asincrónico para obtener redenciones por fecha
        public async Task<IEnumerable<RedemptiondateDto>> GetRedemptionsByDateAsync(DateTime date)
        {
            // Obtiene las redenciones del repositorio por fecha
            var redemptions = await _redemptionRepository.GetRedemptionsByDateAsync(date);
            // Mapea los modelos de redenciones a una colección de DTOs de redención por ID
            return _mapper.Map<IEnumerable<RedemptiondateDto>>(redemptions);
        }
    }
}
