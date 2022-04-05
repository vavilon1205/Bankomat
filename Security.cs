using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class Security
    {
        // Выводит: "Ваш выбор:"
        public static string EnterInformation()
        {
            Console.WriteLine("\nВаш выбор: ");
            string information = Console.ReadLine();

            return information;
        }


        // Проверяет string на int выдает true или false
        public static bool NumberCheckInt(string a)
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


        // Проверяет введенный пинкод
        


        // Ввод номера меню для перехода + проверка
        public static int EnterMenu(int menuFirst, int menuLast, int menuReturn, int shiftForward)
        {
            
            string enter;
            bool a = NumberCheckInt(enter = EnterInformation());
            if (a == true)
            {
                int number = Convert.ToInt32(enter);
                if(number >= menuFirst & number <= menuLast)
                {
                    if(number == 0)
                    {
                        Console.Clear();
                        return number;
                    }
                    else { Console.Clear(); return number + shiftForward; }
                    
                }
                else { Console.Clear(); return menuReturn; }
            }
            else if(enter == "") { Console.Clear(); return 0; } 
            
            else { Console.Clear(); return menuReturn; }
            
        }


        // Проверяет string на decimal выдает true или false
        public static bool NumberCheckDecimal(string a)
        {
            decimal b;
            while (true)
            {
                if (decimal.TryParse(a, out b))

                {
                    b = Convert.ToDecimal(a);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        // Проверка введенного пинкода для записи на карту
        public static bool NumberEnterPinCodeWriteCard(string a)
        {
            int b;
            while (true)
            {
                if (int.TryParse(a, out b) & a.Length == 4)

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
    }
}
