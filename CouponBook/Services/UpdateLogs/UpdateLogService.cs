using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.UpdateLogs;

namespace CouponBook.Services.UpdateLogs
{
    public class UpdateLogService : IUpdateLogService
    {
    
        public readonly IUpdateLogRepository _updateLogRepository;
        public UpdateLogService(IUpdateLogRepository updateLogRepository){
            _updateLogRepository = updateLogRepository;
        }
        
    }
}