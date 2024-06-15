using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponBook.Models
{
    public interface Redemption
    {
        public int Id { get; set;}
        public int CouponId { get; set;}
        public int CustomerUserId { get; set;}
        public DateTime RedemptionDate { get; set;}
        public Decimal FinalValueWithDiscount { get; set;}
        public int PurchaseId { get; set;}



        public Coupon Coupons { get; set; }
        public CustomerUser CustomerUsers { get; set; }
        public Purchase Purchases { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

        
    }
}