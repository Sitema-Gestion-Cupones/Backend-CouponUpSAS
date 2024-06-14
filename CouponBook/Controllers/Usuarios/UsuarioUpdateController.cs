using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Usuarios
{
    public class UsuarioUpdateController : ControllerBase
    {
        public readonly IUsuarioServices _usuarioServices;

        public UsuarioUpdateController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }
        
    }
}