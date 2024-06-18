// Importa los espacios de nombres necesarios para el proyecto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper; // Importa AutoMapper para la configuración de perfiles de mapeo
using CouponBook.Dtos; // Importa las definiciones de los DTOs
using CouponBook.Models; // Importa los modelos de datos

namespace CouponBook.Utils // Define el espacio de nombres para utilidades personalizadas
{
    // Define un perfil de AutoMapper para el usuario
    public class CustomUserProfile : Profile
    {
        // Constructor donde se configuran los mapeos
        public CustomUserProfile()
        {
            // Configura el mapeo de CustomerUser a CustomerUserLoginDto
            CreateMap<CustomerUser, CustomerUserLoginDto>();
            
            // Configura el mapeo de CustomerUser a CustomerUserSignupDto
            CreateMap<CustomerUser, CustomerUserSignupDto>();
        } 
    }

    // Define un perfil de AutoMapper para las compras
    public class PurchaseProfile : Profile
    {
        // Constructor donde se configuran los mapeos
        public PurchaseProfile()
        {
            // Configura el mapeo bidireccional entre Purchase y PurchaseDto
            CreateMap<Purchase, PurchaseDto>().ReverseMap();
            
            // Configura el mapeo bidireccional entre Purchase y PurchaseDtoId
            CreateMap<Purchase, PurchaseDtoId>().ReverseMap();
        }
    }

    // Define un perfil de AutoMapper para las redenciones
    public class RedemptionProfile : Profile
    {
        // Constructor donde se configuran los mapeos
        public RedemptionProfile()
        {
            // Configura el mapeo bidireccional entre RedemptionCreateDto y Redemption
            CreateMap<RedemptionCreateDto, Redemption>().ReverseMap();
            
            // Configura el mapeo bidireccional entre RedemptionIdDto y Redemption
            CreateMap<RedemptionIdDto, Redemption>().ReverseMap();

            // Configura el mapeo bidireccional entre RedemptiondateDto y Redemption
            CreateMap<RedemptiondateDto, Redemption>().ReverseMap();
        }
    }
}
