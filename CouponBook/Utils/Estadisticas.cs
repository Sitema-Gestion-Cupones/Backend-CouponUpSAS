using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Data;

namespace CouponBook.Utils
{
    public class Estadisticas
    {
        private readonly CouponBaseContext _context;

        public Estadisticas(CouponBaseContext context){
            _context = context;
        }
        // busca redenciones en unrango
        public int GetTotalRedemptions(DateTime startDate, DateTime endDate){
            var redemptions = _context.Redemptions
                .Count(r => r.RedemptionDate >= startDate && r.RedemptionDate <= endDate);

            return redemptions;
        }

        //trae redenciones por usuario
        public IEnumerable<object> GetRedemptionsByUserAsArray(){
            
            var redemptionsByUser = _context.Redemptions.GroupBy(r => r.CustomerUserId) 
                //nuevo objeto de clave valor como en js
                .Select(g => new {               
                    UserId = g.Key, //id del liente              
                    Count = g.Count()             
                })
                .ToList();                      

            return redemptionsByUser; 
        }

        //total de facturas
        public int GetTotalInvoices(){
            var totalInvoices = _context.Invoices.Count();
            return totalInvoices;
        }

        //monto total de facturas
        public decimal GetTotalInvoicedAmount(){
            var totalAmount = _context.Invoices.Sum(i => i.Price);
            return totalAmount;
        }
        //cupones con total de redenciones 
        public IEnumerable<object> GetCouponRedemptionCounts(){
            var couponRedemptions = _context.Coupons
                .Select(coupon => new
                {
                    CouponId = coupon.Id,
                    RedemptionCount = coupon.RedemptionCount
                })
                .ToList();

            return couponRedemptions;
        }
    }
}