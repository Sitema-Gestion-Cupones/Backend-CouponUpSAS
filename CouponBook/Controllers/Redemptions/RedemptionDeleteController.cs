using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Purchases;
using CouponBook.Services.Redemptions;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Redemptions
{
    public class RedemptionDeleteController : ControllerBase
    {   
        public readonly IRedemptionService _redemptionService;
        public RedemptionDeleteController(IRedemptionService redemptionService){
            _redemptionService = redemptionService;
        }
        
    }
}