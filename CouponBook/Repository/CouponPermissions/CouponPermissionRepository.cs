using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CouponBook.Data;
using CouponBook.Services.Emails;
using Microsoft.AspNetCore.Identity;

namespace CouponBook.Repository.CouponPermissions
{
    public class CouponPermissionRepository : ICouponPermissionRepository     
    {
        public readonly CouponBaseContext _context;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CouponPermissionRepository(CouponBaseContext context,  IMapper mapper,IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;
        }
        
    }
}