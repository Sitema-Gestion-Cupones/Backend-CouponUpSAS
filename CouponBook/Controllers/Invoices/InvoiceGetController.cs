using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Invoices;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Invoices
{
    public class InvoiceGetController : ControllerBase
    {   
        public readonly IInvoiceService _invoiceService;
        public InvoiceGetController(IInvoiceService invoiceService){
            _invoiceService = invoiceService;
        }
        
    }
}