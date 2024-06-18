using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CouponBook.Dtos
{
    public class CouponDto
    {
        
        public string? Name { get; set; }
        [Required]
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
        public Decimal DiscountValue { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? Category { get; set; }
        public Decimal? ValueFrom { get; set; }
        public int MaxRedemptionsPerUser { get; set; }

    }
    public class CouponCreateDto
    {
        
    }
}