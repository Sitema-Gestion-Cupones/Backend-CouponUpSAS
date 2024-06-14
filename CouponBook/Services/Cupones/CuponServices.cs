using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.Cupones;

namespace CouponBook.Services.Cupones
{
    public class CuponServices : ICuponServices
    {
        public readonly ICuponRepository _cuponRepository;
        public CuponServices(ICuponRepository cuponRepository){
            _cuponRepository = cuponRepository;
        }
    }
}