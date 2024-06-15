using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CouponBook.Data;

namespace CouponBook.Repository.Invoices
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public readonly CouponBaseContext _context;
        private readonly IMapper _mapper;

        public InvoiceRepository(CouponBaseContext context,  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        
    }
}