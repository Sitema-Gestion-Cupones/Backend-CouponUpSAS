using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Redemptions;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Redemptions
{
    public class RedemptionPutController : ControllerBase
    {   
        public readonly IRedemptionService _redemptionService;
        public RedemptionPutController(IRedemptionService redemptionService){
            _redemptionService = redemptionService;
        }
        
    }
}