using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.CustomerUsers;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.CustomerUsers
{
    public class CustomerUserGetController : ControllerBase
    {   
        public readonly ICustomerUserService _customerUserService;
        public CustomerUserGetController(ICustomerUserService customerUserService){
            _customerUserService = customerUserService;
        }
        
    }
}