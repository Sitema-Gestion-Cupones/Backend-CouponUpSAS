using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponBook.Models
{
    public class Coupon
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ActivationDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MarketingUserId { get; set; }
        public string? Status { get; set; }
        public int RedemptionCount { get; set; }
        public int MaxRedemptions { get; set; }
        public string? DiscountType { get; set; }
        public Decimal DiscountVulue { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? Category { get; set; }
        public Decimal? ValueFrom { get; set; }
        public int MaxRedemptionsPerUser { get; set; }

        public MarketingUser? MarketingUser { get; set; }

        public ICollection<CouponPermission>? CouponPermissions { get; set; }
        public ICollection<Redemption>? Redemptions { get; set; }
        public ICollection<UpdateLog>? UpdateLogs { get; set; }
        
    }
}