using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CouponBook.Dtos;
using CouponBook.Models;

namespace CouponBook.Utils
{
    public class CustomUserProfile : Profile
    {
       public CustomUserProfile()
       {
            CreateMap<CustomerUser, CustomerUserLoginDto>();
            CreateMap<CustomerUser, CustomerUserSignupDto>();
       } 
    }
}