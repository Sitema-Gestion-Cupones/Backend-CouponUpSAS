using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CouponBook.Data;
using CouponBook.Services.Emails;

namespace CouponBook.Repository.Purchases
{
    public class PurchaseRepository : IPurchaseRepository
    {
        public readonly CouponBaseContext _context;
        private readonly IMapper _mapper;
         private readonly IEmailService _emailService;

        public PurchaseRepository(CouponBaseContext context,  IMapper mapper, IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;
        }
        
        
    }
}