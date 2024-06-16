using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Dtos;


namespace CouponBook.Repository.CustomerUsers
{
    public interface ICustomerUserRepository
    {
        Task<CustomerUserSignupDto> customerUserSignup(CustomerUserSignupDto customerUserSignupDto);
    }
}