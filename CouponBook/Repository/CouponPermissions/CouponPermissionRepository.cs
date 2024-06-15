using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CouponBook.Data;

namespace CouponBook.Repository.CouponPermissions
{
    public class CouponPermissionRepository : ICouponPermissionRepository     
    {
        public readonly CouponBaseContext _context;
        private readonly IMapper _mapper;

        public CouponPermissionRepository(CouponBaseContext context,  IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
    }
}