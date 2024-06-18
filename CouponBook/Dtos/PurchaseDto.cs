// Importa los espacios de nombres necesarios para el proyecto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponBook.Dtos // Define el espacio de nombres para los DTOs (Data Transfer Objects)
{
    // Define una clase DTO para representar una compra sin ID
    public class PurchaseDto
    {
        // Propiedad para el valor de la compra
        public Decimal Value { get; set; }
        
        // Propiedad para el ID del usuario cliente
        public int CustomerUsersId { get; set; }
    }

    // Define una clase DTO para representar una compra con ID
    public class PurchaseDtoId
    {
        // Propiedad para el ID de la compra
        public int Id { get; set; }
        
        // Propiedad para el valor de la compra
        public Decimal Value { get; set; }
        
        // Propiedad para el ID del usuario cliente
        public int CustomerUsersId { get; set; }
    }
}