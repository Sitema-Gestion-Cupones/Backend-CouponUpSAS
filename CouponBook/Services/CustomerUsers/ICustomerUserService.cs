using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Dtos;
using CouponBook.Utils;

namespace CouponBook.Services.CustomerUsers
{
    public interface ICustomerUserService
    {
        Task<ResponseUtils<CustomerUserSignupDto>> customerUserSignup(CustomerUserSignupDto customerUserSignupDto);
    }
}