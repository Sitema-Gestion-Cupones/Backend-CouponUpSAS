using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CouponBook.Models;

namespace CouponBook.Data
{
    public class CouponBaseContext : DbContext
    {
        public CouponBaseContext(DbContextOptions<CouponBaseContext> options): base(options){
            
        }

        public DbSet<CouponPermission> CouponPermissions { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CustomerUser> CustomerUsers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<MarketingUser> MarketingUsers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Redemtion> Redemtions { get; set; }
        public DbSet<UpdateLog> UpdateLogs { get; set; }
    }
    
}