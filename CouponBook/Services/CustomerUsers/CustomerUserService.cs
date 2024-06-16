using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Dtos;
using CouponBook.Repository.CustomerUsers;
using CouponBook.Utils;

namespace CouponBook.Services.CustomerUsers
{
    public class CustomerUserService : ICustomerUserService
    {    
        public readonly ICustomerUserRepository _customerUserRepository;
        public CustomerUserService(ICustomerUserRepository customerUserRepository){
            _customerUserRepository = customerUserRepository;
        }

        //------------------------------------------- REGISTRAR USUARIO ------------------------------------------------------------------
        public async Task<ResponseUtils<CustomerUserSignupDto>> customerUserSignup(CustomerUserSignupDto customerUserSignupDto)
        {
            var customerUser = await _customerUserRepository.customerUserSignup(customerUserSignupDto);

            if(customerUser != null)
            {
                // Retorno de la respuesta éxitosa con la estructura de la clase 'ResponseUtils':
                 return new ResponseUtils<CustomerUserSignupDto>(true, new List<CustomerUserSignupDto>{customerUser}, null!, 201, message: "¡Registro Exitoso!");
            }
            else
            {
                return new ResponseUtils<CustomerUserSignupDto>(false, null!, null!, 404, message: "¡No se pudo realizar su registro Intente nuevamente");
            }

           

        }
    }
}