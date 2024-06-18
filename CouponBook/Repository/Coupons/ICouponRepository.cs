using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Dtos;
using CouponBook.Models;

namespace CouponBook.Repository.Coupons
{
    public interface ICouponRepository
    {
        Task<bool> CouponExists(string code);
        Task AddCoupon(CouponDto coupon);
        IEnumerable<Coupon> GetAllCoupons();
    }
}