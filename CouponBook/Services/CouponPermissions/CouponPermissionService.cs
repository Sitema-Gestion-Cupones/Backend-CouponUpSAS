using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponBook.Repository.CouponPermissions;

namespace CouponBook.Services.CouponPermissions
{
    public class CouponPermissionService : ICouponPermissionService
    {    
        public readonly ICouponPermissionRepository _couponPermissionService;
        public CouponPermissionService(ICouponPermissionRepository couponPermissionService){
            _couponPermissionService = couponPermissionService;
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