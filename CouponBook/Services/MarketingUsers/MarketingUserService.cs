using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.MarketingUsers;

namespace CouponBook.Services.MarketingUsers
{
    public class MarketingUserService : IMarketingUserService
    {
    
        public readonly IMarketingUserRepository _marketingUserRepository;
        public MarketingUserService(IMarketingUserRepository marketingUserRepository){
            _marketingUserRepository = marketingUserRepository;
        }
        
    }
}