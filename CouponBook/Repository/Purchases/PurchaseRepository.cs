using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CouponBook.Data;

namespace CouponBook.Repository.Purchases
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public readonly CouponBaseContext _context;
        private readonly IMapper _mapper;

        public PurchaseRepository(CouponBaseContext context,  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        
    }
}