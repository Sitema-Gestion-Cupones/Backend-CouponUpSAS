using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Dtos;
using CouponBook.Models;
using CouponBook.Repository.Coupons;

namespace CouponBook.Services.Coupons
{
    public class CouponService : ICouponService
    {    
        public readonly ICouponRepository _couponRepository;
        public CouponService(ICouponRepository couponRepository){
            _couponRepository = couponRepository;
        }

        public Task<bool> CouponExistsAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<CouponDto> CreateCouponAsync(CouponDto coupon)
        {
            throw new NotImplementedException();
        }
    }
}