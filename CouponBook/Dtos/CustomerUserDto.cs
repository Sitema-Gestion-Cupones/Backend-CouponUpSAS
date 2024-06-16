using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CouponBook.Dtos
{

    // Dto  para que nuestro Usuario pueda ingresar a nuestra Api
    public class CustomerUserLoginDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }


    // Dto  para que nuestro Usuario pueda registrarse a nuestra Api
    public class CustomerUserSignupDto
    {
        public string? Name { get; set; }

        public string? Email { get; set; }
        public DateOnly DateBirth { get; set; }
        public string? Password { get; set; }
    }
}