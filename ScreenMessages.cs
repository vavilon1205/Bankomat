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
        public static void WellcomeMainMenu()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"Добро пожаловать в главное меню\nСегодня {now}");
        }
        public static void EnterPincode()
        {

            Console.WriteLine("\nВведите пинкод");
        }
        public static void MisstakePincode()
        {
            Console.WriteLine("\nПинкод введен неверно больше 3-х раз!\nКарта заблокированна!\nОбратитесь в отделение банка.");

        }
        public static void MainMenu()
        {
            Console.WriteLine("\nУзнать баланс\t\t\t\t- 1\nСнять наличные\t\t\t\t- 2\nВнести наличные\t\t\t\t- 3\nПрервать операцию и вернуть карту\t- 4");
        }




    }
}
