using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Dtos;

namespace CouponBook.Services.UpdateLogs
{
    public interface IUpdateLogService{
        Task UpdateCouponAsync(int id, CouponUpdateDto updateDto, string pcode);
        Task UpdateCouponStatusAsync(int id, CouponStatusUpdateDto statusDto);
        
    }
}