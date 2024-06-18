// Importa los espacios de nombres necesarios para el proyecto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper; // Importa AutoMapper para la conversión de objetos
using CouponBook.Data; // Importa el contexto de datos
using CouponBook.Models; // Importa los modelos de datos
using CouponBook.Services.Emails; // Importa el servicio de envío de correos
using Microsoft.EntityFrameworkCore; // Importa funcionalidades para Entity Framework Core

namespace CouponBook.Repository.Purchases // Define el espacio de nombres para el repositorio de compras
{
    // Implementa la interfaz IPurchaseRepository para manejar operaciones de compras
    public class PurchaseRepository : IPurchaseRepository
    {
        // Declara una propiedad para el contexto de la base de datos
        public readonly CouponBaseContext _context;
        
        // Declara una propiedad para el mapeo de objetos
        private readonly IMapper _mapper;
        
        // Declara una propiedad para el servicio de envío de correos
        private readonly IEmailService _emailService;

        // Constructor que recibe el contexto, el mapeador y el servicio de correo
        public PurchaseRepository(CouponBaseContext context, IMapper mapper, IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;
        }

        // Método asincrónico para agregar una nueva compra
        public async Task<Purchase> AddPurchaseAsync(Purchase purchase)
        {
            // Agrega la compra al contexto
            _context.Purchases.Add(purchase);
            
            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();
            
            // Retorna la compra agregada
            return purchase;
        }

        // Método asincrónico para obtener una compra por su ID
        public async Task<Purchase> GetPurchaseByIdAsync(int id)
        {
            // Busca y retorna la compra con el ID especificado
            return await _context.Purchases.FirstOrDefaultAsync(p => p.Id == id);
        }

        // Método asincrónico para obtener todas las compras
        public async Task<IEnumerable<Purchase>> GetAllPurchasesAsync()
        {
            // Retorna todas las compras en la base de datos
            return await _context.Purchases.ToListAsync();
        }
    }
}