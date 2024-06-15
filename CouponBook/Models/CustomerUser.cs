using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponBook.Models
{
    public class CustomerUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime DateBirth { get; set; }
        public string? Password { get; set; }


        public ICollection<Purchase>? Purchases { get; set; }
        public ICollection<Redemption>? Redemptions { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }
    }
}