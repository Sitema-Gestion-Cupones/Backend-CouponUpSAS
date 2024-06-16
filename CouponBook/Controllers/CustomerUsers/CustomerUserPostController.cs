using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Dtos;
using CouponBook.Services.CustomerUsers;
using CouponBook.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.CustomerUsers
{
    public class CustomerUserPostController : ControllerBase
    {   
        public readonly ICustomerUserService _customerUserService;
        public CustomerUserPostController(ICustomerUserService customerUserService){
            _customerUserService = customerUserService;
        }

        [HttpPost("/customeruser/signup/"), AllowAnonymous]
        public async Task<ActionResult<ResponseUtils<CustomerUserSignupDto>>> customerUserSignup([FromBody] CustomerUserSignupDto customerUserSignupDto)
        {
            
            var response = await _customerUserService.customerUserSignup(customerUserSignupDto);
            // Condicional que determina el código HTTP:
            if(response.Code == 201)
            {
                return StatusCode(201, response);
            }
            else if(response.Code == 406)
            {
                return StatusCode(406, response);
            }
            else
            {
                return StatusCode(422, response);
            }
        }

        
        
    }
}