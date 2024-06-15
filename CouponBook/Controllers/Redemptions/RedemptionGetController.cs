using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Redemptions;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Redemptions
{
    public class RedemptionGetController : ControllerBase
    {   
        public readonly IRedemptionService _redemptionService;
        public RedemptionGetController(IRedemptionService redemptionService){
            _redemptionService = redemptionService;
        }
        
    }
}