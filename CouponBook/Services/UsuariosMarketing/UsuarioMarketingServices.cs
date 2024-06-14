using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.UsuariosMarketing;

namespace CouponBook.Services.UsuariosMarketing
{
    public class UsuarioMarketingServices : IUsuarioMarketingServices
    {
        public readonly IUsuarioMarketingRepository _usuarioMarketingRepository;
        public UsuarioMarketingServices(IUsuarioMarketingRepository usuarioMarketingRepository){
            _usuarioMarketingRepository = usuarioMarketingRepository;
        }
        
    }
}