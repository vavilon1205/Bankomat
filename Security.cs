using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class Security
    {
        
        public static string EnterInformation()
        {
           string enter = Console.ReadLine();
           
           return enter;
        }
       
        public static bool NumberCheck(string a)
        {
            int b;
            while (true)
            {
                if (int.TryParse(a, out b))

                {
                    b = Convert.ToInt32(a);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static int EnterPinkode(int menuFirst, int menuSecond)
        {
            //int pincode;
            string enter;
            int lenghtString;
            bool a = NumberCheck(enter = EnterInformation());
            if (a == true)
            {
                //pincode = Convert.ToInt32(EnterInformation());
                lenghtString = enter.Length;
                if(lenghtString >= 0 & lenghtString <= 4)
                {
                    return menuSecond;
                }
                else { return menuFirst; }
                
                
            }
            else { return menuFirst; }
            
        }
    }
}
