using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.MarketingUsers;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.MarketingUsers
{
    public class MarketingUserPutController : ControllerBase
    {   
        public readonly IMarketingUserService _marketingUserService;
        public MarketingUserPutController(IMarketingUserService marketingUserService){
            _marketingUserService = marketingUserService;
        }
        
    }
}