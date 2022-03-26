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
            bool createBoolCard = true;                 // Переменная цикла меню создания карт
            bool readBoolCard = true;                   // Переменная цикла меню чтения карт
            bool editBoolCard = true;                   // Переменная цикла меню редактирования карт
            bool renameBoolCard = true;                 // Переменная цикла изменения данных карт
            bool deleteBoolCard = true;                 // Переменная цикла удаления карт


            int menu = 1;                               // Переменная меню главного цикла программы
            int menuAdminInt = 1;                       // Переменная меню администратора
            int menuAdminIntCreateCard = 1;             // Переменная меню создания и редактирования карт
            int createIntCard = 1;                      // Переменная меню создания карт
            int readIntCard = 1;                        // Переменная меню чтения карт
            int editIntCard = 1;                     // Переменная меню редактирования карт
            int renameIntCard = 1;                      // Переменная подменю изменения данных карт
            int deleteIntCard = 1;                      // Переменная подменю удаления карт

            int attempt = 1;                            // Переменная значения ошибки
            string parth = "Cards.txt";                  // Путь хранения карт
            int numberCard = 1;                        // Переменная возврата номера по счету карты

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
                                    menuAdminInt = Security.EnterMenu(0, 2, 1, 1);
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
                                                menuAdminIntCreateCard = Security.EnterMenu(0, 2, 1, 1);
                                                createIntCard = 1;
                                                createBoolCard = true;
                                                readBoolCard = true;
                                                readIntCard = 1;


                                                Console.Clear();

                                                break;
                                            // МЕНЮ СОЗДАНИЯ КАРТ
                                            case 2:
                                                while (createBoolCard == true)
                                                {
                                                    switch (createIntCard)
                                                    {
                                                        // Выход из меню создания карт
                                                        case 0:
                                                            createBoolCard = false;
                                                            menuAdminIntCreateCard = 1;
                                                            break;
                                                        // Создание карт
                                                        case 1:
                                                            createIntCard = Cards.WriteCard(parth, 0);
                                                            Console.Clear();
                                                            break;
                                                    }
                                                }
                                                break;
                                            // МЕНЮ ЧТЕНИЯ КАРТ
                                            case 3:
                                                while (readBoolCard == true)
                                                {
                                                    switch (readIntCard)
                                                    {
                                                        // Выход из меню чтения карт
                                                        case 0:
                                                            readBoolCard = false;
                                                            menuAdminIntCreateCard = 1;
                                                            break;
                                                        // чтение карт
                                                        case 1:
                                                            numberCard = Cards.ReadCards(parth);
                                                            if (numberCard > 0) 
                                                            {
                                                                menuAdminIntCreateCard = 4;
                                                                editBoolCard = true;
                                                                editIntCard = 1;
                                                                readBoolCard = false; 
                                                            }
                                                            if (numberCard == 0) { readIntCard = 0; }
                                                            Console.Clear();
                                                            break;
                                                    }
                                                }
                                                break;

                                            // МЕНЮ РЕДАКТИРОВАНИЯ КАРТ
                                            case 4:
                                                
                                                while (editBoolCard == true)
                                                {
                                                    switch (editIntCard)
                                                    {
                                                        // Выход из меню редактирования карт
                                                        case 0:
                                                            editBoolCard = false;
                                                            menuAdminIntCreateCard = 3;
                                                            
                                                            break;
                                                        // меню редактирования карт
                                                        case 1:

                                                            editIntCard = Cards.EditDataCards(parth, numberCard);
                                                            Console.Clear();
                                                            if (editIntCard == 0) 
                                                            {
                                                                readBoolCard = true;
                                                                break; 
                                                            }
                                                            else if (editIntCard == 1) 
                                                            {
                                                                editBoolCard = false;
                                                                renameBoolCard = true;
                                                                renameIntCard = 1;
                                                                menuAdminIntCreateCard = 5; 
                                                            }
                                                            
                                                            break;
                                                            
                                                    }
                                                }
                                                break;

                                            // ИЗМЕНЕНИЕ ДАННЫХ КАРТ
                                            case 5:     
                                                while (renameBoolCard == true)
                                                {
                                                    switch (renameIntCard)
                                                    {
                                                        // Выход из изменения данных карт
                                                        case 0:
                                                            renameBoolCard = false;
                                                            editBoolCard = true;
                                                            menuAdminIntCreateCard = 4;
                                                            break;
                                                        // изменения данных карт
                                                        case 1:
                                                            renameIntCard = Cards.RenameDataCards(parth, 0, numberCard);
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
