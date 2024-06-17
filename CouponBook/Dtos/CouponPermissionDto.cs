using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponBook.Dtos
{
    // dto para crear un permiso
    public class CouponPermissionDto
    {
        public int CouponId { get; set;}
     
        
    }
    // deto para traer datos
     public class CouponGetPermissionDto 
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int CouponId { get; set; }
        public int MarketingUserId { get; set; }
        public DateTime RequestDate { get; set; }
        public string MarketingUserName { get; set; }
        public string CouponCode { get; set; }
    }
}