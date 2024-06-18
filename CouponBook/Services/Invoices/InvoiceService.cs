using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.Invoices;

namespace CouponBook.Services.Invoices
{
    public class InvoiceService : IInvoiceService
    {
    
        public readonly IInvoiceRepository _invoiceRepository;
        public InvoiceService(IInvoiceRepository invoiceRepository){
            _invoiceRepository = invoiceRepository;
        }
        
    }
}