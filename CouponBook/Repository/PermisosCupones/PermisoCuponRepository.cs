using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CouponBook.Data;

namespace CouponBook.Repository.PermisosCupones
{
    public class PermisoCuponRepository : IPermisoCuponRepository
    {
        public readonly CouponBaseContext _context;
        public readonly IMapper _mapper;
        public PermisoCuponRepository(CouponBaseContext context, IMapper mapper ){
            _context = context;
            _mapper = mapper;
        }   
        
    }
}