using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.UpdateLogs;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.UpdateLogs
{
    public class UpdateLogGetController : ControllerBase
    {   
        public readonly IUpdateLogService _updateLogService;
        public UpdateLogGetController(IUpdateLogService updateLogService){
            _updateLogService = updateLogService;
        }
        
    }
}