using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.Redemptions;

namespace CouponBook.Services.Redemptions
{
    public class RedemptionService : IRedemptionService
    {    
        public readonly IRedemptionRepository _redemptionRepository;
        public RedemptionService(IRedemptionRepository redemptionRepository){
            _redemptionRepository = redemptionRepository;
        }
        
    }
}