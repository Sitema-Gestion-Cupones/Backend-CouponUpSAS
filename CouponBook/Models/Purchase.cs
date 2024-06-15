using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponBook.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public Decimal Value { get; set; }
        public int CustomerUsersId { get; set; }

        
        public CustomerUser? CustomerUsers { get; set; }
        public Redemption? Redemptions { get; set; }
        
    }
}