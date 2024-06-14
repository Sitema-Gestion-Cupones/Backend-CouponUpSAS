using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CouponBook.Data;

namespace CouponBook.Repository.Redenciones
{
    public class RedencionRepository : IRedencionRepository
    {
        public readonly CouponBaseContext _context;
        public readonly IMapper _mapper;
        public RedencionRepository(CouponBaseContext context, IMapper mapper ){
            _context = context;
            _mapper = mapper;
        }   
        
    }
}