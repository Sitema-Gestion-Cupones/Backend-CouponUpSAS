using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.CouponPermissions;

namespace CouponBook.Services.CouponPermissions
{
    public class CouponPermissionService : ICouponPermissionService
    {    
        public readonly ICouponPermissionRepository _couponPermissionService;
        public CouponPermissionService(ICouponPermissionRepository couponPermissionService){
            _couponPermissionService = couponPermissionService;
        }
        
    }
}