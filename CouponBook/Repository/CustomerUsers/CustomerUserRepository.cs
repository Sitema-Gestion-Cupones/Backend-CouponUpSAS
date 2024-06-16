using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CouponBook.Data;
using CouponBook.Services.Emails;
using CouponBook.Custom;
using CouponBook.Dtos;
using CouponBook.Models;

namespace CouponBook.Repository.CustomerUsers
{
    public class CustomerUserRepository : ICustomerUserRepository
    {
        public readonly CouponBaseContext _context;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly Utilities _utils;

        public CustomerUserRepository(CouponBaseContext context,  IMapper mapper,IEmailService emailService, Utilities utils)
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;   
            _utils = utils;
        }

        public async Task<CustomerUserSignupDto> customerUserSignup(CustomerUserSignupDto customerUserSignupDto)
        {
            if (customerUserSignupDto == null)
            {
                throw new ArgumentNullException(nameof(customerUserSignupDto), "El DTO de registro de usuario no puede ser nulo.");
            }

            if (string.IsNullOrEmpty(customerUserSignupDto.Password))
            {
                throw new ArgumentException("La contraseña no puede ser nula o vacía.", nameof(customerUserSignupDto.Password));
            }


            // Log para verificar los datos recibidos
            Console.WriteLine($"Received: Name={customerUserSignupDto.Name}, Email={customerUserSignupDto.Email}, DateBirth={customerUserSignupDto.DateBirth}, Password={customerUserSignupDto.Password}");





            var customerUser = new CustomerUser
            {
                Name = customerUserSignupDto.Name,
                Email = customerUserSignupDto.Email,
                DateBirth = customerUserSignupDto.DateBirth,
                Password = _utils.encriptarSHA256(customerUserSignupDto.Password)
            };

            await _context.CustomerUsers.AddAsync(customerUser);
            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerUserSignupDto>(customerUserSignupDto);
        }
    }
}