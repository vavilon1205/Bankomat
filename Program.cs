using System;

namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool program = true;                        // Переменная главного цикла программы
            bool menuAdminBool = true;                  // Переменная цикла меню администратора
            bool menuAdminBoolCreateCard = true;        // Переменная цикла меню создания и редактирования карт
            bool menuAdminBoolDirectory = true;   // Переменная цикла меню создания директории хранения карт
            int menu = 1;                               // Переменная меню главного цикла программы
            int menuAdminInt = 1;                       // Переменная меню администратора
            int menuAdminIntCreateCard = 1;             // Переменная меню создания и редактирования карт
            int menuAdminIntDirectory = 1;        // Переменная меню создания директории хранения карт
            int attempt = 1;                            // Переменная значения ошибки


            while (program == true)
            {
                switch (menu)
                {
                    // Выход из программы
                    case 0:
                        ScreenMessages.MisstakePincode();
                        program = false;
                        break;

                    // МЕНЮ АДМИНИСТРАТОРА
                    case 1:
                        while (menuAdminBool == true)
                        {
                            switch (menuAdminInt)
                            {
                                // Выход из меню администратора
                                case 0:
                                    menuAdminBool = false;
                                    menu = 2;


                                    break;
                                // Главное меню администратора
                                case 1:
                                    MenuAdministrator.WellcomeMenuAdministrator();
                                    menuAdminInt = Security.EnterMenu(0, 5, 1, 1);
                                    menuAdminIntCreateCard = 1;
                                    menuAdminBoolCreateCard = true;
                                    Console.Clear();

                                    break;
                                // МЕНЮ СОЗДАНИЯ И РЕДАКТИРОВАНИЯ КАРТ
                                case 2:
                                    while (menuAdminBoolCreateCard == true)
                                    {
                                        switch (menuAdminIntCreateCard)
                                        {
                                            // Выход из меню создания и редактирования карт
                                            case 0:
                                                menuAdminBoolCreateCard = false;
                                                menuAdminInt = 1;
                                                break;
                                            // Главное меню создания и редактирования карт
                                            case 1:
                                                Cards.WellcomeMenuCreateCards();
                                                menuAdminIntCreateCard = Security.EnterMenu(0, 5, 1, 1);
                                                menuAdminIntDirectory = 1;
                                                menuAdminBoolDirectory = true;

                                                Console.Clear();

                                                break;
                                            // МЕНЮ СОЗДАНИЯ ДИРЕКТОРИИ ХРАНЕНИЯ КАРТ
                                            case 2:
                                                while (menuAdminBoolDirectory == true)
                                                {
                                                    switch (menuAdminIntDirectory)
                                                    {
                                                        // Выход из меню создания директории хранения карт
                                                        case 0:
                                                            menuAdminBoolDirectory = false;
                                                            menuAdminIntCreateCard = 1;
                                                            break;

                                                        case 1:
                                                            Cards.DirectoryCardMessageMenu();
                                                            menuAdminIntDirectory = Security.EnterMenu(0, 2, 1, 1);
                                                            Console.Clear();
                                                            break;

                                                        case 2:
                                                            Cards.CreateDirectoryCard();
                                                            menuAdminIntDirectory = 1;
                                                            Console.Clear();
                                                            break;
                                                    }
                                                    


                                                }

                                               


                                                break;





                                        }



                                    }


                                    break;





                            }

                        }
                        break;

                    // Выбор карты
                    case 2:
                        ScreenMessages.ChoiceCard();


                        break;

                    // Приветсвие, ввод пинкода.
                    case 3:

                        ScreenMessages.Wellcome();
                        ScreenMessages.EnterPincode();
                        menu = Security.EnterPinkode(2, 3, 0, attempt);
                        attempt++;
                        Console.Clear();
                        break;

                    // Главное меню
                    case 4:
                        ScreenMessages.WellcomeMainMenu();
                        ScreenMessages.MainMenu();

                        Console.ReadKey();
                        break;










                }







            }



        }
    }
}
