using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CouponBook.Data;

namespace CouponBook.Repository.Cupones
{
    public class CuponRepository : ICuponRepository
    {
        public readonly CouponBaseContext _context;
        public readonly IMapper _mapper;
        public CuponRepository(CouponBaseContext context, IMapper mapper ){
            _context = context;
            _mapper = mapper;
        }   
        
    }
}