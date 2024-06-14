using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.Usuarios
{
    public class UsuarioDeleteController : ControllerBase
    {
        public readonly IUsuarioServices _usuarioServices;

        public UsuarioDeleteController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }  
    }
}