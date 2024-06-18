using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CouponBook.Data;
using SpreadsheetLight;

namespace CouponBook.Utils
{
    public class Estadisticas
    {
        private readonly CouponBaseContext _context;

        public Estadisticas(CouponBaseContext context)
        {
            _context = context;
        }

        public int GetTotalRedemptions(DateTime startDate, DateTime endDate)
        {
            var redemptions = _context.Redemptions
                .Count(r => r.RedemptionDate >= startDate && r.RedemptionDate <= endDate);

            return redemptions;
        }

        public IEnumerable<object> GetRedemptionsByUserAsArray()
        {
            var redemptionsByUser = _context.Redemptions.GroupBy(r => r.CustomerUserId)
                .Select(g => new
                {
                    UserId = g.Key,
                    Count = g.Count()
                })
                .ToList();

            return redemptionsByUser;
        }

        public int GetTotalInvoices()
        {
            var totalInvoices = _context.Invoices.Count();
            return totalInvoices;
        }

        public decimal GetTotalInvoicedAmount()
        {
            var totalAmount = _context.Invoices.Sum(i => i.Price);
            return totalAmount;
        }

        public IEnumerable<object> GetCouponRedemptionCounts()
        {
            var couponRedemptions = _context.Coupons
                .Select(coupon => new
                {
                    CouponId = coupon.Id,
                    RedemptionCount = coupon.RedemptionCount
                })
                .ToList();

            return couponRedemptions;
        }
        public void EstadisticasExccel(string filePath)
{
    SLDocument sl = new SLDocument(); //intancia del archivo

    // Total de redenciones en la fecha
    var startDate = DateTime.Now.AddDays(-30);
    var endDate = DateTime.Now;

    DataTable dtTotalRedemptions = new DataTable();
    dtTotalRedemptions.Columns.Add("PARAMETRO", typeof(string));
    dtTotalRedemptions.Columns.Add("VALOR", typeof(int));
    dtTotalRedemptions.Rows.Add("Total Redemptions", GetTotalRedemptions(startDate, endDate));

    sl.ImportDataTable("A1", dtTotalRedemptions, true);

    // Redenciones por usuario
    var redemptionsByUser = GetRedemptionsByUserAsArray();

    DataTable dtRedemptionsByUser = new DataTable();
    dtRedemptionsByUser.Columns.Add("User ID", typeof(int));
    dtRedemptionsByUser.Columns.Add("Redemptions Count", typeof(int));

    int rowStartRedemptionsByUser = 5; // Iniciar en la fila 4 para esta tabla
    foreach (var item in redemptionsByUser)
    {
        var userId = (int)item.GetType().GetProperty("UserId").GetValue(item, null);
        var count = (int)item.GetType().GetProperty("Count").GetValue(item, null);
        dtRedemptionsByUser.Rows.Add(userId, count);
    }

    sl.ImportDataTable(rowStartRedemptionsByUser, 1, dtRedemptionsByUser, true);

    // Total Invoices
    DataTable dtTotalInvoices = new DataTable();
    dtTotalInvoices.Columns.Add("PARAMETRO", typeof(string));
    dtTotalInvoices.Columns.Add("VALOR", typeof(int));
    dtTotalInvoices.Rows.Add("Total Invoices", GetTotalInvoices());

    int rowStartTotalInvoices = rowStartRedemptionsByUser + dtRedemptionsByUser.Rows.Count + 2; // Añadir un espacio entre tablas
    sl.ImportDataTable(rowStartTotalInvoices, 1, dtTotalInvoices, true);

    // Total Invoiced Amount
    DataTable dtTotalInvoicedAmount = new DataTable();
    dtTotalInvoicedAmount.Columns.Add("PARAMETRO", typeof(string));
    dtTotalInvoicedAmount.Columns.Add("VALOR ", typeof(decimal));
    dtTotalInvoicedAmount.Rows.Add("Total Invoiced Amount", GetTotalInvoicedAmount());

    int rowStartTotalInvoicedAmount = rowStartTotalInvoices + 4; // Añadir un espacio entre tablas
    sl.ImportDataTable(rowStartTotalInvoicedAmount, 1, dtTotalInvoicedAmount, true);

    
    var couponRedemptions = GetCouponRedemptionCounts(); //cantidad de redenciones por cupon

    DataTable dtCouponRedemptions = new DataTable();
    dtCouponRedemptions.Columns.Add("Coupon ID", typeof(int));
    dtCouponRedemptions.Columns.Add("NUMERO DE REDENCIONES", typeof(int));

    int rowStartCouponRedemptions = rowStartTotalInvoicedAmount + 2; // Añadir un espacio entre tablas
    foreach (var item in couponRedemptions)
    {
        var couponId = (int)item.GetType().GetProperty("CouponId").GetValue(item, null);
        var redemptionCount = (int)item.GetType().GetProperty("RedemptionCount").GetValue(item, null);
        dtCouponRedemptions.Rows.Add(couponId, redemptionCount);
    }

    sl.ImportDataTable(rowStartCouponRedemptions, 1, dtCouponRedemptions, true);

    sl.SaveAs(filePath);
}
        
    }
}
