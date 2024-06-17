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
        }

        public async Task UpdateCouponStatusAsync(int id, CouponStatusUpdateDto statusDto){
            var coupon = await  _context.Coupons.FindAsync(id);
            if (coupon == null)
            {
                throw new KeyNotFoundException($"Coupon with id {id} not found.");
            }

            _mapper.Map(statusDto, coupon);
            _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync();
        }

        private bool UserCanUpdateCoupon(Coupon coupon, CouponGetPermissionDto permissionDto){

            
            int loggedInUserId = _marketingId.GetId(); 

    
            var user = _context.MarketingUsers.SingleOrDefault(u => u.Id == loggedInUserId);
            if (user == null){

                throw new KeyNotFoundException($"User with id {loggedInUserId} not found.");
            }
            var userRole = user.Role;// Obtener el rol del usuario que inicióo sesion 

            // Verificar si el usuario es el dueño del cupón o administrador
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