using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponBook.Dtos
{

    // Dto para Crear una redención
    public class RedemptionCreateDto
    {
        public int CouponId { get; set;}
        public int CustomerUserId { get; set;}
        public Decimal FinalValueWithDiscount { get; set;}
        public int PurchaseId { get; set;}
    }

    // Dto para Listar todos las redenciones

}



