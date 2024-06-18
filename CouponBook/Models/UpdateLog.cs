using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponBook.Models
{
    public class UpdateLog
    {
        public int Id { get; set;}
        public int MarketingUserId { get; set;}
        public string? PermissionCode { get; set;}
        public DateTime UpdateTimestamp { get; set;}
        public string? UpdateType { get; set;}
        public int CouponId { get; set;}
        public string? PreviousValue { get; set;}
        public string? Newvalue { get; set;}


        // Relación entre Entidades
        public MarketingUser? MarketingUsers { get; set;}
        public Coupon? Coupons { get; set;}

    }
}