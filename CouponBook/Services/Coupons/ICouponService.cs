using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Dtos;
using CouponBook.Models;

namespace CouponBook.Services.Coupons
{
    public interface ICouponService
    {
        Task<bool> CouponExistsAsync(string code);
        Task<CouponDto> CreateCouponAsync(CouponDto coupon);
    }
}