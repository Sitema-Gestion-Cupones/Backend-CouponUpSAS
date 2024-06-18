using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.UpdateLogs;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.UpdateLogs
{
    public class UpdateLogPutController : ControllerBase
    {   
        public readonly IUpdateLogService _updateLogService;
        public UpdateLogPutController(IUpdateLogService updateLogService){
            _updateLogService = updateLogService;
        }
        
    }
}