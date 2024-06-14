using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Services.RegistroActualizaciones;
using Microsoft.AspNetCore.Mvc;

namespace CouponBook.Controllers.RegistroActualizaciones
{
    public class RegistroActualizacionDeleteController : ControllerBase
    {
        public readonly IRegistroActualizacionServices _registroActualizacionServices;

        public RegistroActualizacionDeleteController(IRegistroActualizacionServices registroActualizacionServices)
        {
            _registroActualizacionServices = registroActualizacionServices;
        }
        
    }
}