using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.UpdateLogs;
using CouponBook.Models;
using CouponBook.Data;
using AutoMapper;
using CouponBook.Dtos;
using Microsoft.EntityFrameworkCore;
using CouponBook.Utils;

namespace CouponBook.Services.UpdateLogs
{
    public class UpdateLogService : IUpdateLogService
    {
    
        public readonly IUpdateLogRepository _updateLogRepository;
        private readonly CouponBaseContext _context;
        private readonly IMapper _mapper;
        public readonly GetMarketingId _marketingId;
        public UpdateLogService(GetMarketingId marketingId,IUpdateLogRepository updateLogRepository,CouponBaseContext context,IMapper mapper){
            _updateLogRepository = updateLogRepository;
            _context = context;
            _mapper= mapper;
            _marketingId=marketingId;
        
        }

         public async Task UpdateCouponAsync(int id, CouponUpdateDto updateDto, string pcode){
            var coupon = await  _context.Coupons.FindAsync(id);

            if (coupon == null){

                throw new KeyNotFoundException($"Coupon with id {id} not found.");
            }

            // guardar cupon viejo
            string oldCoupon = ConvertCouponToString(coupon);
            //______________________________________________________________

            var permissionDto = new CouponGetPermissionDto{
                Code = pcode
            };

            if (!UserCanUpdateCoupon(coupon, permissionDto)){

                throw new UnauthorizedAccessException("User is not authorized to update this coupon.");
            }

            _mapper.Map(updateDto, coupon);
            _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync();
            //guardar nuevo cupon
            string newCoupon = ConvertCouponToString(coupon);

            //registro  en historial 
            var updateLog = new UpdateLog
            {
                MarketingUserId = _marketingId.GetId(),
                PermissionCode = pcode,
                UpdateTimestamp = DateTime.Now,
                UpdateType = "body",
                CouponId = id,
                PreviousValue = oldCoupon,
                Newvalue = newCoupon
                
            };

            await _context.UpdateLogs.AddAsync(updateLog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCouponStatusAsync(int id, CouponStatusUpdateDto statusDto, string pcode){
            var coupon = await  _context.Coupons.FindAsync(id);
            if (coupon == null){
                throw new KeyNotFoundException($"Coupon with id {id} not found.");
            }
            string oldCoupon = ConvertCouponToString(coupon);

            var permissionDto = new CouponGetPermissionDto{
                Code = pcode
            };

            if (!UserCanUpdateCoupon(coupon, permissionDto)){

                throw new UnauthorizedAccessException("User is not authorized to update this coupon.");
            }

            _mapper.Map(statusDto, coupon);
            _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync();
            //nuevo cupon
            string newCoupon = ConvertCouponToString(coupon);
            //registro  en historial 
             var updateLog = new UpdateLog
            {
                MarketingUserId = _marketingId.GetId(),
                PermissionCode = pcode,
                UpdateTimestamp = DateTime.Now,
                UpdateType = "status",
                CouponId = id,
                PreviousValue = oldCoupon,
                Newvalue = newCoupon
                
            };

            await _context.UpdateLogs.AddAsync(updateLog);
            await _context.SaveChangesAsync();
        }

        public string ConvertCouponToString(Coupon coupon){
            return $"Id:{coupon.Id}, Name:{coupon.Name}, Code:{coupon.Code}, Description:{coupon.Description}, " +
           $"CreationDate:{coupon.CreationDate}, ActivationDate:{coupon.ActivationDate}, EndDate:{coupon.EndDate}, " +
           $"MarketingUserId:{coupon.MarketingUserId}, Status:{coupon.Status}, RedemptionCount:{coupon.RedemptionCount}, " +
           $"MaxRedemptions:{coupon.MaxRedemptions}, DiscountType:{coupon.DiscountType}, DiscountValue:{coupon.DiscountValue}, " +
           $"UpdateDate:{coupon.UpdateDate}, Category:{coupon.Category}, ValueFrom:{coupon.ValueFrom}, " +
           $"MaxRedemptionsPerUser:{coupon.MaxRedemptionsPerUser}";
        }

        private bool UserCanUpdateCoupon(Coupon coupon, CouponGetPermissionDto permissionDto){

            
            int loggedInUserId = _marketingId.GetId(); 

    
            var user = _context.MarketingUsers.SingleOrDefault(u => u.Id == loggedInUserId);
            if (user == null){

                throw new KeyNotFoundException($"User with id {loggedInUserId} not found.");
            }
            var userRole = user.Role;// Obtener el rol del usuario que inicióo sesion 

            // Verificar si el usuario es el dueño del cupón oes administrador
            if (coupon.MarketingUserId == loggedInUserId || userRole == "administrator"){
                return true;
            }

            // Si no es dueo ni administradorb verificar si tiene permiso con el código
            var permission = _context.CouponPermissions.FirstOrDefault(p => p.Code == permissionDto.Code &&
                p.CouponId == coupon.Id &&
                p.MarketingUserId == loggedInUserId);

            return permission != null;
        }
        
    }
}