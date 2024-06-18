using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CouponBook.Data;
using CouponBook.Dtos;
using CouponBook.Models;
using CouponBook.Services.Emails;
using CouponBook.Utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CouponBook.Repository.Coupons
{
    public class CouponRepository : ICouponRepository
    {
        public readonly CouponBaseContext _context;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly GetMarketingId _getMarketingId;

        public CouponRepository(CouponBaseContext context,  IMapper mapper,IEmailService emailService, GetMarketingId getMarketingId)
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;
            _getMarketingId = getMarketingId;
        }

        public async Task<bool> CouponExists(string code)
        {
            return await _context.Coupons.AnyAsync(c => c.Code == code);
        }
        /*======================= CREACION DE LOS CUPONES ==============================*/
        public async Task AddCoupon(CouponCreateDto coupon)
        {
            /*Validaciones*/

            // Validacion de existencia de codigo 
            if (await CouponExists(coupon.Code))
            {
                throw new Exception("El código de cupón ya existe");
            }


            int GetIdMarkeing = _getMarketingId.GetId();

            /*==== asignacion de valores al objeto tipo cupon ====*/
           var NewCoupon = new Coupon
           {
                Name = coupon.Name,
                Code = coupon.Code,
                Description = coupon.Description,
                ActivationDate = coupon.ActivationDate,
                EndDate = coupon.EndDate,
                MaxRedemptions = coupon.MaxRedemptions,
                DiscountType = coupon.DiscountType, // hacerle una validacion de que si ingrese porcentual o neto "percentage y net "
                DiscountValue = coupon.DiscountValue,
                Category = coupon.Category,
                ValueFrom = coupon.ValueFrom,
                MaxRedemptionsPerUser = coupon.MaxRedemptionsPerUser,

                // Default values  
                MarketingUserId = GetIdMarkeing,
                Status = "inactive",
                UpdateDate = DateTime.Now,
                RedemptionCount = 0,
                CreationDate = DateTime.Now,
            };  

            await _context.Coupons.AddAsync(NewCoupon);
            await _context.SaveChangesAsync();
            
        }

        /*================= LISTAR TODOS LOS CUPONES ===================*/
        public IEnumerable<Coupon> GetAllCoupons()
        {
            return _context.Coupons.Include(m => m.MarketingUser).ToList();
        }

    }
}