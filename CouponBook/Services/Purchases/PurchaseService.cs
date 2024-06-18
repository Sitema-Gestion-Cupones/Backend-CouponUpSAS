// Importa los espacios de nombres necesarios para el proyecto
using System.Threading.Tasks;
using AutoMapper; // Importa AutoMapper para la conversión de objetos
using CouponBook.Dtos; // Importa las definiciones de los DTOs
using CouponBook.Models; // Importa los modelos de datos
using CouponBook.Repository.Purchases; // Importa el repositorio de compras

namespace CouponBook.Services.Purchases // Define el espacio de nombres para el servicio de compras
{
    // Implementa la interfaz IPurchaseService para manejar operaciones de compras
    public class PurchaseService : IPurchaseService
    {
        // Declara una propiedad para el repositorio de compras
        private readonly IPurchaseRepository _purchaseRepository;
        
        // Declara una propiedad para el mapeo de objetos
        private readonly IMapper _mapper;

        // Constructor que recibe el repositorio de compras y el mapeador
        public PurchaseService(IPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        // Método asincrónico para agregar una nueva compra
        public async Task<PurchaseDto> AddPurchaseAsync(PurchaseDto purchaseDto)
        {
            // Mapea el DTO de compra a un modelo de compra
            var purchase = _mapper.Map<Purchase>(purchaseDto);
            
            // Agrega la compra usando el repositorio
            var addedPurchase = await _purchaseRepository.AddPurchaseAsync(purchase);
            
            // Mapea el modelo de compra agregado de vuelta a un DTO
            return _mapper.Map<PurchaseDto>(addedPurchase);
        }

        // Método asincrónico para obtener una compra por su ID
        public async Task<PurchaseDtoId> GetPurchaseByIdAsync(int id)
        {
            // Obtiene la compra desde el repositorio por ID
            var purchase = await _purchaseRepository.GetPurchaseByIdAsync(id);
            
            // Mapea el modelo de compra a un DTO con ID
            return _mapper.Map<PurchaseDtoId>(purchase);
        }

        // Método asincrónico para obtener todas las compras
        public async Task<IEnumerable<PurchaseDtoId>> GetAllPurchasesAsync()
        {
            // Obtiene todas las compras desde el repositorio
            var purchases = await _purchaseRepository.GetAllPurchasesAsync();
            
            // Mapea la lista de modelos de compras a una lista de DTOs con ID
            return _mapper.Map<IEnumerable<PurchaseDtoId>>(purchases);
        }
    }
}