using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponBook.Utils
{
    public class GeneradorDeCodigos
    {
        public string CodigoPermiso()
        {
            Random random = new Random();
            char[] code = new char[5];

            for (int i = 0; i < 5; i++)
            {
                if (random.Next(2)%2 == 0){
                    // Letras minúsculas en ASCII
                    code[i]=(char)random.Next(97, 123);
                }else{
                    // Números del 0 al 9 en ASCII
                    code[i]=(char)random.Next(48, 58);
                }
                
            }

            return new string(code);
        }

        public string CodigoFactura()
        {
            Random random = new Random();
            char[] code = new char[5];

            for (int i = 0; i < 5; i++)
            {
                if (random.Next(2)%2 == 0){
                    // Letras minúsculas en ASCII
                    code[i]=(char)random.Next(97, 123);
                }else{
                    // Números del 0 al 9 en ASCII
                    code[i]=(char)random.Next(48, 58);
                }
                
            }

            string generate =new string(code)+"-Invoice";

            return generate;
        }
        
        
    }
}