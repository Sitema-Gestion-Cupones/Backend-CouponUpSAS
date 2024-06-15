using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Invoices;
using CouponBook.Services.MarketingUsers;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.MarketingUsers
{
    public class MarketingUserDeleteController : ControllerBase
    {   
        public readonly IMarketingUserService _marketingUserService;
        public MarketingUserDeleteController(IMarketingUserService marketingUserService){
            _marketingUserService = marketingUserService;
        }
        
    }
}