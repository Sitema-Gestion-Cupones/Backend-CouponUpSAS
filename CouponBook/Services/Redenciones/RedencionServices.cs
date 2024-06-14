using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.Redenciones;

namespace CouponBook.Services.Redenciones
{
    public class RedencionServices : IRedencionServices
    {
        public readonly IRedencionRepository _redencionRepository;
        public RedencionServices(IRedencionRepository redencionRepository){
            _redencionRepository = redencionRepository;
        }
        
    }
}