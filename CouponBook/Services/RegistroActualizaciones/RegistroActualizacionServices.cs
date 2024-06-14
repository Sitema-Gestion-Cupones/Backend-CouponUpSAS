using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.RegistroActualizaciones;

namespace CouponBook.Services.RegistroActualizaciones
{
    public class RegistroActualizacionServices : IRegistroActualizacionServices
    {
        public readonly IRegistroActualizacionRepository _registroActualizacionRepository;
        public RegistroActualizacionServices(IRegistroActualizacionRepository registroActualizacionRepository){
            _registroActualizacionRepository = registroActualizacionRepository;
        }
    }
}