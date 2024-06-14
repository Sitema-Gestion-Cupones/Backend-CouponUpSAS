using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.UsuariosMarketing;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.UsuariosMarketing
{
    public class UsuarioMarketingDeleteController : ControllerBase
    {
        public readonly IUsuarioMarketingServices _usuarioMarketingServices;

        public UsuarioMarketingDeleteController(IUsuarioMarketingServices usuarioMarketingServices)
        {
            _usuarioMarketingServices = usuarioMarketingServices;
        }
        
    }
}