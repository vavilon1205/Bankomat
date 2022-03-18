using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class MenuAdministrator
    {
        public static void WellcomeMenuAdministrator()
        {
            
            Console.WriteLine("Меню администратора\n");
            Console.WriteLine("Выход из меню\t\t\t\t - 0");
            Console.WriteLine("Создание и редактирование карт\t\t - 1");
            Console.WriteLine("Пополнение банкомата\t\t\t - 2");
        }

        
    }
}
