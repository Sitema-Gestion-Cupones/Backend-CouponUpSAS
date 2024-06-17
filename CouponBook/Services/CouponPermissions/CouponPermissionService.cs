using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.CouponPermissions;
using CouponBook.Models;
using CouponBook.Dtos;
using CouponBook.Data;
using CouponBook.Utils;
using Microsoft.EntityFrameworkCore;
using CouponBook.Services.Emails;

namespace CouponBook.Services.CouponPermissions
{
    public class CouponPermissionService : ICouponPermissionService
    {    
        public readonly ICouponPermissionRepository _couponPermissionService;
        public readonly CouponBaseContext  _context;
        public readonly GetMarketingId     _marketingId;

        private readonly IEmailService _emailService;
        public CouponPermissionService(ICouponPermissionRepository couponPermissionService, CouponBaseContext  context,GetMarketingId marketingId,IEmailService emailService){
            _couponPermissionService = couponPermissionService;
            _context = context;
            _marketingId= marketingId;
            _emailService = emailService;
        }

         public async Task CreatePermissionAsync(CouponPermissionDto couponPermissionDto){
            // verificar que el codigo de permiso no exita en la base de datos 
            string code;
            bool codeExists;
            do
            {
                code = CodigoPermiso();
                codeExists = await _context.CouponPermissions.AnyAsync(cp => cp.Code == code);

            } while (codeExists==true);

            int marketingLogId = _marketingId.GetId();

            var couponPermission = new CouponPermission
            {
                CouponId = couponPermissionDto.CouponId,
                MarketingUserId = marketingLogId,
                Code = code 
            };

            _context.CouponPermissions.Add(couponPermission);
            await _context.SaveChangesAsync();

            //una vez creado se envi un correo con el codigo 
            var marketingUser = _context.MarketingUsers.Find(marketingLogId);
            

            if (marketingUser != null)
            {
                var subject = "Codigo de permiso";
                var marketingUsermessage = $"Hola {marketingUser.Name},\n tu código para generar acualizaciones en el cupón {couponPermissionDto.CouponId} es {code}.";

                _emailService.SendEmail(marketingUser.Email, subject, marketingUsermessage);
                
            }
            
        }

        public string CodigoPermiso(){

            Random random = new Random();
            string codeString = "";
            // se declara un arrego de char de tamaño 5 (maximo permitido en la base de datso)
            char[] code = new char[5];

            for (int i = 0; i < 5; i++){

                if (random.Next(2) == 0){ //si el numero que eligió es par 
                
                    // convierto  a char un numero que reprecenta las letras minucualas en ascii
                    code[i] = (char)random.Next(97, 123); 
                }
                else{
                
                    //  convierto  a char un numero que reprecenta numeros del 0 al 9 n ascii
                    code[i] = (char)random.Next(48, 58);
                }
            }
            // convierto el arreglo de char en string porque es el tpo de dato que retrna la funcioón
            foreach(var letter in code){
                codeString += letter;
            }


        return codeString;

        }
        
    }
}