using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.CustomerUsers;

namespace CouponBook.Services.CustomerUsers
{
    public class CustomerUserService : ICustomerUserService
    {    
        public readonly CustomerUserRepository _customerUserRepository;
        public CustomerUserService(CustomerUserRepository customerUserRepository){
            _customerUserRepository = customerUserRepository;
        }
        
    }
}