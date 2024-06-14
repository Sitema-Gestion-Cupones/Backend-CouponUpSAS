using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.PermisosCupones;

namespace CouponBook.Services.PermisosCupones
{
    public class PermisoCuponServices : IPermisoCuponServices
    {
        public readonly IPermisoCuponRepository _permisoCuponRepository;
        public PermisoCuponServices(IPermisoCuponRepository permisoCuponRepository){
            _permisoCuponRepository = permisoCuponRepository;
        }
    }
}