using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponBook.Models
{
    public class CouponPermission
    {
        public int Id { get; set;}
        public string? Code { get; set;}
        public int CouponId { get; set;}
        public int MarketingUserId { get; set;}



        public Coupon? Coupon { get; set;} 
        public MarketingUser? MarketingUser { get; set;} 
        
    }
}