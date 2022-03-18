using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class Cards
    {

        public static void WellcomeMenuCreateCards()
        {

            Console.WriteLine("Меню создания карт\n");
            Console.WriteLine("Выход из меню\t\t\t\t - 0");
            Console.WriteLine("Установка директории хранения карт\t - 1");
            Console.WriteLine("Создание карт\t\t\t\t - 2");
            Console.WriteLine("Редактирование карт\t\t\t - 3");
        }

        public static void DirectoryCardMessageMenu()
        {
            Console.WriteLine("Путь хранения карт по умолчанию:\n");
            Console.WriteLine(@"E:\Programming\C# projects\Bankomat\StorageCards");
            Console.WriteLine("\nОставить путь директории прежним и выйти назад\t - 0");
            Console.WriteLine("Изменить путь директории\t\t\t - 1");
        }


        public static void CreateDirectoryCard()
        {
            Console.WriteLine("Укажите путь директории:\n");
            string path = Console.ReadLine();
            string pathDefault = @"E:\Programming\C# projects\Bankomat\StorageCards";
            if (path.Length == 0)
            {
                DirectoryCardMessageMenu();
            }
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (!dir.Exists)
                {
                    dir.Create();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Некорректный ввод!");
                Thread.Sleep(5000);
                Console.Clear();


            }

            DirectoryCardMessageMenu();
        }

    }
}
