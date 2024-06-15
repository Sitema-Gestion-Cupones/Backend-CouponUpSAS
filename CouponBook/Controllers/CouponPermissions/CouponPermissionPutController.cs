using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.CouponPermissions;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.CouponPermissions
{
    public class CouponPermissionPutController : ControllerBase
    {   
        public readonly ICouponPermissionService _couponPermissionService;
        public CouponPermissionPutController(ICouponPermissionService couponPermissionService){
            _couponPermissionService = couponPermissionService;
        }
        
    }
}