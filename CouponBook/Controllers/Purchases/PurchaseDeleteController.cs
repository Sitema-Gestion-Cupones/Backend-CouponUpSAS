using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.MarketingUsers;
using CouponBook.Services.Purchases;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Purchases
{
    public class PurchaseDeleteController : ControllerBase
    {   
        public readonly IPurchaseService _purchaseService;
        public PurchaseDeleteController(IPurchaseService purchaseService){
            _purchaseService = purchaseService;
        }
        
    }
}