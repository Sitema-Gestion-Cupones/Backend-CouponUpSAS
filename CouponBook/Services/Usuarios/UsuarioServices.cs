using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.Usuarios;

namespace CouponBook.Services.Usuarios
{
    public class UsuarioServices : IUsuarioServices
    {
        public readonly IUsuarioRepository _usuarioRepository;
        public UsuarioServices(IUsuarioRepository usuarioRepository){
            _usuarioRepository = usuarioRepository;
        }
        
    }
}