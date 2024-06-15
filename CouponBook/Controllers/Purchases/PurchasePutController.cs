using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Purchases;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Purchases
{
    public class PurchasePutController : ControllerBase
    {   
        public readonly IPurchaseService _purchaseService;
        public PurchasePutController(IPurchaseService purchaseService){
            _purchaseService = purchaseService;
        }
        
    }
}