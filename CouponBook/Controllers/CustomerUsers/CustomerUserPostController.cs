using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Dtos;
using CouponBook.Services.CustomerUsers;
using CouponBook.Utils;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.CustomerUsers
{
    public class CustomerUserPostController : ControllerBase
    {   
        public readonly ICustomerUserService _customerUserService;
        public readonly IValidator<CustomerUserSignupDto> _customerUserSignupValidator;
    
        public CustomerUserPostController(ICustomerUserService customerUserService, IValidator<CustomerUserSignupDto> customerUserSignupValidator)
        {
            _customerUserService = customerUserService;
            _customerUserSignupValidator = customerUserSignupValidator;
        }

        [HttpPost("/customeruser/signup/"), AllowAnonymous]
        public async Task<ActionResult<ResponseUtils<CustomerUserSignupDto>>> customerUserSignup([FromBody] CustomerUserSignupDto customerUserSignupDto)
        {           
            var validationResult = await _customerUserSignupValidator.ValidateAsync(customerUserSignupDto);
            
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                var validationResponse = new ResponseUtils<CustomerUserSignupDto>(false, null, null, 422, "Validation Failed", errors);
                return StatusCode(422, validationResponse);
            }

            var serviceResponse = await _customerUserService.customerUserSignup(customerUserSignupDto);
            return StatusCode(serviceResponse.Code, serviceResponse);
        }
    }

        
        
}
