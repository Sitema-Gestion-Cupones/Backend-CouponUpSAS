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

namespace CouponBook.Services.UpdateLogs
{
    public class UpdateLogService : IUpdateLogService
    {
    
        public readonly IUpdateLogRepository _updateLogRepository;
        private readonly CouponBaseContext _context;
        private readonly IMapper _mapper;
        public UpdateLogService(IUpdateLogRepository updateLogRepository,CouponBaseContext context,IMapper mapper){
            _updateLogRepository = updateLogRepository;
            _context = context;
            _mapper= mapper;
        
        }

         public async Task UpdateCouponAsync(int id, CouponUpdateDto updateDto)
        {
            var coupon = await  _context.Coupons.FindAsync(id);
            if (coupon == null)
            {
                throw new KeyNotFoundException($"Coupon with id {id} not found.");
            }

            _mapper.Map(updateDto, coupon);
            _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCouponStatusAsync(int id, CouponStatusUpdateDto statusDto)
        {
            var coupon = await  _context.Coupons.FindAsync(id);
            if (coupon == null)
            {
                throw new KeyNotFoundException($"Coupon with id {id} not found.");
            }

            _mapper.Map(statusDto, coupon);
            _context.Coupons.Update(coupon);
            await _context.SaveChangesAsync();
        }
        
    }
}