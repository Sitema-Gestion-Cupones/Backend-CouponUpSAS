using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CouponBook.Data;

namespace CouponBook.Repository.Redemptions
{
    public class RedemptionRepository : IRedemptionRepository
    {
        public readonly CouponBaseContext _context;
        private readonly IMapper _mapper;

        public RedemptionRepository(CouponBaseContext context,  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        
    }
}