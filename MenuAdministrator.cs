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
            Console.WriteLine("Настройки\t\t\t\t - 3");
        }
        
       
        public static void WellcomeMenuBanknotes()
        {
            Console.WriteLine("Меню пополнения банкомата купюрами\n");

            Console.WriteLine("Выход из меню\t\t\t\t - 0");
            Console.WriteLine("Информация о купюрах в банкомате\t - 1");
            Console.WriteLine("Пополнение купюрами\t\t\t - 2");


        }

        // Меню создания карт
        public static void WellcomeMenuCreateCards()
        {

            Console.WriteLine("Меню создания карт\n");

            Console.WriteLine("Выход из меню\t\t\t\t - 0");
            Console.WriteLine("Создание карт\t\t\t\t - 1");
            Console.WriteLine("Редактирование карт\t\t\t - 2");
        }

        // Меню настройки
        public static void WellcomeMenuSettings()
        {

            Console.WriteLine("Меню настройки\n");

            Console.WriteLine("Выход из меню\t\t\t\t\t - 0");
            Console.WriteLine("Установка кода входа в режим администратора\t - 1");
            Console.WriteLine("Установка дирректории создания хранилища карт\t - 2");
            Console.WriteLine("Установка пути сохранения чека баланса счета\t - 3");
        }

    }
}
