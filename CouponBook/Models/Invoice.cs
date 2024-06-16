using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponBook.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public Decimal Price { get; set; }
        public int CustomerUserId { get; set; }
        public int RedemptionId { get; set; }


        public CustomerUser? CustomerUser { get; set; }
        public Redemption? Redemption { get; set; }

    }
}