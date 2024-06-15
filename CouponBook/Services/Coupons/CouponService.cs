using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.Coupons;

namespace CouponBook.Services.Coupons
{
    public class CouponService : ICouponService
    {    
        public readonly ICouponRepository _couponRepository;
        public CouponService(ICouponRepository couponRepository){
            _couponRepository = couponRepository;
        }
        
    }
}