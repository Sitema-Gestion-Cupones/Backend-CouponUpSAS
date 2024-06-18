// Importa los espacios de nombres necesarios para el proyecto
using System.Threading.Tasks;
using AutoMapper; // Importa AutoMapper para mapeo de objetos
using CouponBook.Data;
using CouponBook.Dtos; // Importa los DTOs para redenciones
using CouponBook.Models; // Importa los modelos de datos
using CouponBook.Repository.Redemptions; // Importa el repositorio de redenciones
using CouponBook.Utils;
using Microsoft.EntityFrameworkCore;

namespace CouponBook.Services.Redemptions // Define el espacio de nombres para el servicio de redenciones
{
    // Implementa la interfaz IRedemptionService para gestionar operaciones de redenciones
    public class RedemptionService : IRedemptionService
    {
        // Declara una propiedad solo de lectura para el repositorio de redenciones
        private readonly IRedemptionRepository _redemptionRepository;
       
        private readonly IMapper _mapper; // no usado por ahora 
        
        private readonly CouponBaseContext _context;
        private readonly GeneradorDeCodigos _codigos;

        
        public RedemptionService(GeneradorDeCodigos codigos,CouponBaseContext context,IRedemptionRepository redemptionRepository, IMapper mapper)
        {
            _redemptionRepository = redemptionRepository;
            _mapper = mapper;//
            _context = context;
            _codigos = codigos;
        }

    
       public async Task RedeemCouponAsync(int couponId, int customerUserId, int purchaseId){
        
        var purchase = await _context.Purchases.FirstOrDefaultAsync(p => p.Id == purchaseId ); //compra

        if (purchase == null || purchase.CustomerUserId != customerUserId)
        {
            throw new Exception("esta compra no exite o no es de este cliente :'( )");
        }

        var purchaseValue = purchase.Value;

        
        var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.Id ==couponId); //obtener el cupon

        if (coupon == null)
        {
            throw new Exception("cupon no encontrado ");
        }

        //verificar si se puede usar 
        if (coupon.Status != "active" || coupon.EndDate < DateTime.Now || coupon.RedemptionCount >= coupon.MaxRedemptions)
        {
            throw new Exception("lo siento, no puedes redimir este cupon , verifica el stado, fecha o lmites de este cupòn ");
        }

        // apliocar el descuento 
        decimal finalValueWithDiscount;
        if (coupon.DiscountType == "percentage")
        {
            finalValueWithDiscount = purchaseValue - (purchaseValue * (coupon.DiscountValue / 100));
        }
        else if (coupon.DiscountType == "net")
        {
            finalValueWithDiscount = purchaseValue - coupon.DiscountValue;
        }
        else
        {
            throw new Exception("verifica si este tipo de descuento exite ");
        }

    // agregar el registro de redenciones
        var redemption = new Redemption
        {
             CouponId = couponId,
            CustomerUserId = customerUserId,
            RedemptionDate = DateTime.Now,
            FinalValueWithDiscount = finalValueWithDiscount,
            PurchaseId = purchaseId
        };
        await _context.Redemptions.AddAsync(redemption);

       
        coupon.RedemptionCount++;// se aumenta el uso de cupones 
        _context.Coupons.Update(coupon);
        await _context.SaveChangesAsync();

         // Crear la factura
        var invoice = new Invoice{
            Code =_codigos.CodigoFactura(),
            Price = finalValueWithDiscount,
            CustomerUserId = customerUserId,
            RedemptionId = redemption.Id 
        };

        _context.Invoices.Add(invoice);
        
        

        // uardar los cambios en la base de datos
        await _context.SaveChangesAsync();
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
