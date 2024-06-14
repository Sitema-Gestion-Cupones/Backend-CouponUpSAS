using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CouponBook.Models;

namespace CouponBook.Data
{
    public class CouponBaseContext : DbContext
    {
        public CouponBaseContext(DbContextOptions<CouponBaseContext> options): base(options){
            
        }

        public DbSet<Cupon> Cupones { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<PermisoCupon> PermisosCupones { get; set; }
        public DbSet<Redencion> Redenciones { get; set; }
        public DbSet<RegistroActualizacion> RegistrosActualizaciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioMarketing> UsuariosMarketing { get; set; }
    }
    
}