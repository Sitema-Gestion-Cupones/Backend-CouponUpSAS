using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponBook.Dtos
{
        public class CouponUpdateDto{
            public string? Name { get; set; }
            public string? Description { get; set; }
            public DateTime ActivationDate { get; set; }
            public DateTime EndDate { get; set; }
            public int RedemptionCount { get; set; }
            public int MaxRedemptions { get; set; }
            public string? DiscountType { get; set; }
            public decimal DiscountValue { get; set; }
            public DateTime UpdateDate { get; set; }
            public string? Category { get; set; }
            public decimal? ValueFrom { get; set; }
            public int MaxRedemptionsPerUser { get; set; }
        }

        public class CouponStatusUpdateDto{
                public string Status { get; set; } = string.Empty; // 'activo' o 'inactivo'
        }
    
}