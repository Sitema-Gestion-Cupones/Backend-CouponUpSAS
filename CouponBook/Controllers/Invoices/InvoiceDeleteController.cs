using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.CustomerUsers;
using CouponBook.Services.Invoices;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Invoices
{
    public class InvoiceDeleteController  : ControllerBase
    {   
        public readonly IInvoiceService _invoiceService;
        public InvoiceDeleteController(IInvoiceService invoiceService){
            _invoiceService = invoiceService;
        }
        
    }
}