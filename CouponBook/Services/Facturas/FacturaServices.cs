using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.Facturas;

namespace CouponBook.Services.Facturas
{
    public class FacturaServices : IFacturaServices
    {        
        public readonly IFacturaRepository _facturaRepository;
        public FacturaServices(IFacturaRepository facturaRepository){
            _facturaRepository = facturaRepository;
        }
        
    }
}