using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class ScreenMessages
    {

        public static void Wellcome()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"Добро пожаловать в банкомат\nСегодня {now}");
        }
        public static void EnterPincode()
        {
            
            Console.WriteLine("\nВведите пинкод");
        }




    }
}
