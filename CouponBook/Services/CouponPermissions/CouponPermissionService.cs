using System;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.CouponPermissions;
using CouponBook.Models;
using CouponBook.Dtos;
using CouponBook.Data;
using CouponBook.Utils;
using Microsoft.EntityFrameworkCore;
using CouponBook.Services.Emails;

namespace CouponBook.Services.CouponPermissions
{
    public class CouponPermissionService : ICouponPermissionService
    {
        public readonly ICouponPermissionRepository _couponPermissionService;
        public readonly CouponBaseContext _context;
        public readonly GetMarketingId _marketingId;

        private readonly IEmailService _emailService;
        public CouponPermissionService(ICouponPermissionRepository couponPermissionService, CouponBaseContext context, GetMarketingId marketingId, IEmailService emailService)
        {
            _couponPermissionService = couponPermissionService;
            _context = context;
            _marketingId = marketingId;
            _emailService = emailService;
        }

        public async Task CreatePermissionAsync(CouponPermissionDto couponPermissionDto)
        {
            var coupon = await _context.Coupons
                .Include(c => c.MarketingUser)
                .FirstOrDefaultAsync(c => c.Id == couponPermissionDto.CouponId);

            if (coupon == null)
            {
                throw new Exception($"El cupón con ID {couponPermissionDto.CouponId} no existe.");
            }

            var creatorStatus = await _context.MarketingUsers
                .Where(mu => mu.Id == coupon.MarketingUserId)
                .Select(mu => mu.Status)
                .FirstOrDefaultAsync();

            if (creatorStatus == "active")
            {
                throw new Exception($"El usuario de marketing creador del cupón está activo, no se puede otorgar el permiso.");
            }

            // verificar que el código de permiso no exista en la base de datos 
            string code;
            bool codeExists;
            do
            {
                code = CodigoPermiso();
                codeExists = await _context.CouponPermissions.AnyAsync(cp => cp.Code == code);
            } while (codeExists);

            int marketingLogId = _marketingId.GetId();

            var couponPermission = new CouponPermission
            {
                CouponId = couponPermissionDto.CouponId,
                MarketingUserId = marketingLogId,
                Code = code,
                RequestDate = DateTime.Now
            };

            _context.CouponPermissions.Add(couponPermission);
            await _context.SaveChangesAsync();

            // una vez creado se envía un correo con el código 
            var marketingUser = await _context.MarketingUsers.FindAsync(marketingLogId);

            if (marketingUser != null)
            {
                var subject = "Código de permiso";
                var marketingUsermessage = $"Hola {marketingUser.Name},\n tu código para generar actualizaciones en el cupón {couponPermissionDto.CouponId} es {code}.";

                _emailService.SendEmail(marketingUser.Email, subject, marketingUsermessage);
            }
        }
       public async Task<List<CouponGetPermissionDto>> GetPermissionsByRequestDateAsync(DateTime requestDate){
            if (requestDate.Date > DateTime.Now.Date){

                 throw new Exception("La fecha solicitada no puede ser superior a la de hoy");
            }
            
            var permissions = await _context.CouponPermissions
                .Where(cp => cp.RequestDate.Date == requestDate.Date)
                .Include(cp => cp.MarketingUser)
                .Include(cp => cp.Coupon)
                .ToListAsync();

            return permissions.Select(cp => new CouponGetPermissionDto
            {
                Id = cp.Id,
                Code = cp.Code,
                CouponId = cp.CouponId,
                MarketingUserId = cp.MarketingUserId,
                RequestDate = cp.RequestDate,
                MarketingUserName = cp.MarketingUser?.Name,
                CouponCode = cp.Coupon?.Code
            }).ToList();
        }
        public async Task<List<CouponGetPermissionDto>> GetPermissionsByUserIdAsync(int userId)
        {
            var permissions = await _context.CouponPermissions
                .Where(cp => cp.MarketingUserId == userId)
                .Include(cp => cp.MarketingUser)
                .Include(cp => cp.Coupon)
                .ToListAsync();

            return permissions.Select(cp => new CouponGetPermissionDto
            {
                Id = cp.Id,
                Code = cp.Code,
                CouponId = cp.CouponId,
                MarketingUserId = cp.MarketingUserId,
                RequestDate = cp.RequestDate,
                MarketingUserName = cp.MarketingUser?.Name,
                CouponCode = cp.Coupon?.Code
            }).ToList();
        }

        public string CodigoPermiso()
        {
            Random random = new Random();
            char[] code = new char[5];

            for (int i = 0; i < 5; i++)
            {
                code[i] = random.Next(2) == 0
                    ? (char)random.Next(97, 123) // Letras minúsculas en ASCII
                    : (char)random.Next(48, 58); // Números del 0 al 9 en ASCII
            }

            return new string(code);
        }
    }
}
