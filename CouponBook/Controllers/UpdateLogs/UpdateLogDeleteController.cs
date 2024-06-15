using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Redemptions;
using CouponBook.Services.UpdateLogs;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.UpdateLogs
{
    public class UpdateLogDeleteController : ControllerBase
    {   
        public readonly IUpdateLogService _updateLogService;
        public UpdateLogDeleteController(IUpdateLogService updateLogService){
            _updateLogService = updateLogService;
        }
        
    }
}