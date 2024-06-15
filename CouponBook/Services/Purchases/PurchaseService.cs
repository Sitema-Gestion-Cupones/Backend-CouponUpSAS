using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.Purchases;

namespace CouponBook.Services.Purchases
{
    public class PurchaseService :IPurchaseService
    {    
        public readonly IPurchaseRepository _purchaseRepository;
        public PurchaseService(IPurchaseRepository purchaseRepository){
            _purchaseRepository = purchaseRepository;
        }
        
    }
}