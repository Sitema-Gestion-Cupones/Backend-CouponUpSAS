using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Models;

namespace CouponBook.Models
{
    public class MarketingUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }      


        // Relación entre Entidades
        public ICollection<CouponPermission>? CouponPermissions { get; set; }
        public ICollection<Coupon>? Coupons { get; set; }
        public ICollection<UpdateLog>? UpdateLogs { get; set; }
    }
}