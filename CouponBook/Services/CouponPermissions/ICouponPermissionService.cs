using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Models;
using CouponBook.Dtos;

namespace CouponBook.Services.CouponPermissions
{
    public interface ICouponPermissionService
    {
        Task CreatePermissionAsync(CouponPermissionDto couponPermissionDto);
        Task<List<CouponGetPermissionDto>> GetPermissionsByRequestDateAsync(DateTime requestDate);
    }
}