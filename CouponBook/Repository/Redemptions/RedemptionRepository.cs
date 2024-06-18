// Importa los espacios de nombres necesarios para el proyecto
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper; // Importa AutoMapper para mapeo de objetos
using CouponBook.Data; // Importa el contexto de la base de datos
using CouponBook.Models; // Importa los modelos de datos
using CouponBook.Services.Emails; // Importa el servicio de envío de correos
using Microsoft.EntityFrameworkCore; // Importa funcionalidades de Entity Framework Core

namespace CouponBook.Repository.Redemptions // Define el espacio de nombres para el repositorio de redenciones
{
    // Implementa la interfaz IRedemptionRepository para gestionar las operaciones de redenciones
    public class RedemptionRepository : IRedemptionRepository
    {
        // Declara una propiedad solo de lectura para el contexto de la base de datos
        public readonly CouponBaseContext _context;
        // Declara una propiedad solo de lectura para el mapeo de objetos
        private readonly IMapper _mapper;
        // Declara una propiedad solo de lectura para el servicio de envío de correos
        private readonly IEmailService _emailService;

        // Constructor que recibe el contexto, el mapeador y el servicio de correo
        public RedemptionRepository(CouponBaseContext context, IMapper mapper, IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;
        }

        // Método asincrónico para añadir una nueva redención
        public async Task<Redemption> AddRedemptionAsync(Redemption redemption)
        {
            // Añade la redención al contexto
            _context.Redemptions.Add(redemption);
            // Guarda los cambios de forma asincrónica en la base de datos
            await _context.SaveChangesAsync();
            // Retorna la redención añadida
            return redemption;
        }

        // Método asincrónico para obtener una redención por su ID
        public async Task<Redemption> GetRedemptionByIdAsync(int id)
        {
            // Consulta la redención y sus relaciones, incluyendo cupones, usuarios y compras
            return await _context.Redemptions
                                 .Include(r => r.Coupons)
                                 .Include(r => r.CustomerUsers)
                                 .Include(r => r.Purchases)
                                 .FirstOrDefaultAsync(r => r.Id == id);
        }

        // Método asincrónico para obtener todas las redenciones
        public async Task<IEnumerable<Redemption>> GetAllRedemptionsAsync()
        {
            // Consulta todas las redenciones y sus relaciones, incluyendo cupones, usuarios y compras
            return await _context.Redemptions
                                 .Include(r => r.Coupons)
                                 .Include(r => r.CustomerUsers)
                                 .Include(r => r.Purchases)
                                 .ToListAsync();
        }

        // Método asincrónico para obtener redenciones por fecha
        public async Task<IEnumerable<Redemption>> GetRedemptionsByDateAsync(DateTime date)
        {
            // Consulta las redenciones que coinciden con la fecha especificada
            return await _context.Redemptions
                                 .Include(r => r.Coupons)
                                 .Include(r => r.CustomerUsers)
                                 .Include(r => r.Purchases)
                                 .Where(r => r.RedemptionDate.Date == date.Date)
                                 .ToListAsync();
        }
    }
}
