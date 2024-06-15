using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Purchases;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Purchases
{
    public class PurchasePostController : ControllerBase
    {   
        public readonly IPurchaseService _purchaseService;
        public PurchasePostController(IPurchaseService purchaseService){
            _purchaseService = purchaseService;
        }
        
    }
}