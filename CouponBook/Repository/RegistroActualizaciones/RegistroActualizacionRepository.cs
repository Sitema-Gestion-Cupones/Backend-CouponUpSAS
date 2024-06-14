using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CouponBook.Data;

namespace CouponBook.Repository.RegistroActualizaciones
{
    public class RegistroActualizacionRepository : IRegistroActualizacionRepository
    {
        public readonly CouponBaseContext _context;
        public readonly IMapper _mapper;
        public RegistroActualizacionRepository(CouponBaseContext context, IMapper mapper ){
            _context = context;
            _mapper = mapper;
        }   
        
    }
}