using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.CustomerUsers;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.CustomerUsers
{
    public class CustomerUserPutController : ControllerBase
    {   
        public readonly ICustomerUserService _customerUserService;
        public CustomerUserPutController(ICustomerUserService customerUserService){
            _customerUserService = customerUserService;
        }
        
    }
}