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
            Console.WriteLine("\nВаш выбор: ");
            string information = Console.ReadLine();

            return information;
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

        public static int EnterPinkode(int menuFirst, int menuSecond, int menuThird, int attempt)
        {
            //int pincode;
            if (attempt == 4)
            {
                return menuThird;
            }
            else
            {
                string enter;
                int lenghtString;
                bool a = NumberCheck(enter = EnterInformation());
                if (a == true)
                {
                    //pincode = Convert.ToInt32(EnterInformation());
                    lenghtString = enter.Length;
                    if (lenghtString >= 0 & lenghtString <= 4)
                    {
                        return menuSecond;
                    }
                    else { return menuFirst; }


                }
                else { return menuFirst; }


            }


        }

        public static int EnterMenu(int menuFirst, int menuLast, int menuReturn, int shiftForward)
        {
            
            string enter;
            bool a = NumberCheck(enter = EnterInformation());
            if (a == true)
            {
                int number = Convert.ToInt32(enter);
                if(number >= menuFirst & number <= menuLast)
                {
                    if(number == 0)
                    {
                        return number;
                    }
                    else {return number + shiftForward; }
                    
                }
                else { return menuReturn; }
            }
            else { return menuReturn; }
        }
    }
}
