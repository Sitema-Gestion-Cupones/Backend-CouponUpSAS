using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.UpdateLogs;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.UpdateLogs
{
    public class UpdateLogPostController : ControllerBase
    {   
        public readonly IUpdateLogService _updateLogService;
        public UpdateLogPostController(IUpdateLogService updateLogService){
            _updateLogService = updateLogService;
        }
        
    }
}