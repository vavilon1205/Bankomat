using System;

namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            




            bool program = true;                        // Переменная главного цикла программы
            bool menuAdminBool = true;                  // Переменная цикла меню администратора
            bool menuAdminCreateCartBool = true;        // Переменная цикла создания и редактирования карт
            bool menuAdminBanknotesBool = true;         // Переменная цикла главного меню банкнот
            bool menuMainBalanceBool = true;            // Переменная цикла меню баланса карты
            bool menuMainCashWithdravalBool = true;     // Переменная цикла меню выдачи наличных
            bool menuSettingsBankomat = true;           // Переменная цикла меню настроек банкомата



            int menu = 2;                               // Переменная меню главного цикла программы

            int menuAdmin = 1;                          // Переменная меню администратора
            int menuAdminCreateCard = 1;                // Переменная меню создания и редактирования карт
            int createCard = 1;                         // Переменная меню создания карт
            int readCard = 1;                           // Переменная меню чтения карт
            int editCard = 1;                           // Переменная меню редактирования карт
            int renameCard = 1;                         // Переменная подменю изменения данных карт
            int settingsBankomat = 1;                   // Переменная меню настроек банкомата

            int menuAdminBanknotes = 1;                 // Переменная меню купюр
            int informationBanknotes = 1;               // Переменная подменю информация о купюрах в банкомате
            int editBanknotes = 1;                      // Переменная подменю изменения купюр

            int menuMainBalance = 1;                    // Переменная меню баланса карты
            int menuMainCashWithdraval = 1;             // Переменная меню выдачи наличных





            int numberCard = 1;                         // Переменная возврата номера по счету карты
            string? securyAdminPin;            // Пинкод входа в меню администратора

            DbCreateSet.DbCreateSetValue();

            using (ApplicationContext db = new ApplicationContext())
            {
                var securyCodeMenu = db.SettingsBankomat.ToList();
                


                securyAdminPin = securyCodeMenu[0].securyCode;
                
            }
            while (program == true)
            {
                switch (menu)
                {
                    // Выход из программы
                    case 0:
                        
                        ScreenMessages.MisstakePincode();
                        Console.ReadLine();
                        program = false;
                        break;

                    // МЕНЮ АДМИНИСТРАТОРА
                    case 1:
                        menuAdminBool = true;
                        menuAdmin = 1;
                        while (menuAdminBool == true)
                        {
                            switch (menuAdmin)
                            {
                                // Выход из меню администратора
                                case 0:
                                    menuAdminBool = false;
                                    menu = 2;


                                    break;
                                // Главное меню администратора
                                case 1:
                                    MenuAdministrator.WellcomeMenuAdministrator();
                                    menuAdmin = Security.EnterMenu(0, 3, 1, 1);
                                    menuAdminCreateCard = 1;
                                    menuAdminBanknotes = 1;
                                    Console.Clear();

                                    break;
                                // МЕНЮ СОЗДАНИЯ И РЕДАКТИРОВАНИЯ КАРТ
                                case 2:
                                    menuAdminCreateCartBool = true;
                                    while (menuAdminCreateCartBool == true)
                                    {
                                        
                                        switch (menuAdminCreateCard)
                                        {
                                            // Выход из меню создания и редактирования карт
                                            case 0:
                                                menuAdminCreateCartBool = false;
                                                menuAdmin = 1;
                                                break;
                                            // Главное меню создания и редактирования карт
                                            case 1:
                                                MenuAdministrator.WellcomeMenuCreateCards();
                                                menuAdminCreateCard = Security.EnterMenu(0, 2, 1, 1);
                                                createCard = 1;
                                                readCard = 1;
                                                Console.Clear();

                                                break;
                                            // МЕНЮ СОЗДАНИЯ КАРТ
                                            case 2:
                                                menuAdminBool = true;
                                                while (menuAdminBool == true)
                                                {
                                                    switch (createCard)
                                                    {
                                                        // Выход из меню создания карт
                                                        case 0:
                                                            menuAdminBool = false;
                                                            menuAdminCreateCard = 1;
                                                            break;
                                                        // Создание карт
                                                        case 1:
                                                            createCard = Cards.WriteCard(0);
                                                            Console.Clear();
                                                            break;
                                                    }
                                                }
                                                break;
                                            // МЕНЮ ЧТЕНИЯ КАРТ
                                            case 3:
                                                menuAdminBool = true;
                                                while (menuAdminBool == true)
                                                {
                                                    switch (readCard)
                                                    {
                                                        // Выход из меню чтения карт
                                                        case 0:
                                                            menuAdminBool = false;
                                                            menuAdminCreateCard = 1;
                                                            break;
                                                        // чтение карт
                                                        case 1:
                                                            numberCard = Cards.ReadCards();
                                                            if (numberCard > 0)
                                                            {
                                                                menuAdminCreateCard = 4;
                                                                editCard = 1;
                                                                menuAdminCreateCartBool = true;


                                                            }
                                                            else if (numberCard == 0) { readCard = 0; }
                                                            menuAdminBool = false;
                                                            Console.Clear();
                                                            break;
                                                    }
                                                }
                                                break;

                                            // МЕНЮ РЕДАКТИРОВАНИЯ КАРТ
                                            case 4:
                                                menuAdminBool = true;
                                                while (menuAdminBool == true)
                                                {
                                                    switch (editCard)
                                                    {
                                                        // Выход из меню редактирования карт
                                                        case 0:
                                                            menuAdminBool = false;
                                                            menuAdminCreateCard = 3;

                                                            break;
                                                        // меню редактирования карт
                                                        case 1:

                                                            editCard = Cards.EditDataCards(numberCard);
                                                            Console.Clear();
                                                            if (editCard == 0)
                                                            {
                                                                menuAdminBool = false;
                                                                break;
                                                            }
                                                            else if (editCard == 1)
                                                            {


                                                                renameCard = 1;
                                                                menuAdminCreateCard = 5;
                                                                menuAdminBool = false;
                                                            }
                                                            break;
                                                    }
                                                }
                                                break;

                                            // ИЗМЕНЕНИЕ ДАННЫХ КАРТ
                                            case 5:
                                                menuAdminBool = true;
                                                while (menuAdminBool == true)
                                                {
                                                    switch (renameCard)
                                                    {
                                                        // Выход из изменения данных карт
                                                        case 0:
                                                            menuAdminBool = false;
                                                            menuAdminCreateCard = 4;
                                                            break;
                                                        // изменения данных карт
                                                        case 1:
                                                            renameCard = Cards.RenameDataCards(0, numberCard);
                                                            Console.Clear();
                                                            menuAdminBool = false;
                                                            break;


                                                    }
                                                }
                                                break;

                                        }
                                    }
                                    break;
                                // МЕНЮ ПОПОЛНЕНИЯ БАНКОМАТА КУПЮРАМИ
                                case 3:
                                    menuAdminBanknotesBool = true;
                                    while (menuAdminBanknotesBool == true)
                                    {
                                        switch (menuAdminBanknotes)
                                        {
                                            // Выход из меню пополнения купюрами
                                            case 0:
                                                menuAdminBanknotesBool = false;
                                                menuAdmin = 1;
                                                break;
                                            // меню пополнения купюрами
                                            case 1:
                                                MenuAdministrator.WellcomeMenuBanknotes();
                                                menuAdminBanknotes = Security.EnterMenu(1, 3, 0, 1);
                                                informationBanknotes = 1;
                                                editBanknotes = 1;
                                               
                                                break;

                                            // Подменю информации о купюрах
                                            case 2:
                                                menuAdminBool = true;
                                                while (menuAdminBool == true)
                                                {
                                                    switch (informationBanknotes)
                                                    {
                                                        // Выход из подменюменю информации о купюрах
                                                        case 0:
                                                            menuAdminBanknotes = 1;
                                                            menuAdminBool = false;

                                                            break;
                                                        // Вывод информации о купюрах
                                                        case 1:
                                                            Money.InformationBanknotesBankomat();
                                                            informationBanknotes = Security.EnterMenu(0, 0, 0, 0);
                                                            menuAdminBool = false;
                                                            break;
                                                    }
                                                }
                                                break;
                                            // Подменю изменения купюр
                                            case 3:
                                                menuAdminBool = true;
                                                while (menuAdminBool == true)
                                                {
                                                    switch (editBanknotes)
                                                    {
                                                        // Выход из изменения купюр
                                                        case 0:
                                                            menuAdminBanknotes = 1;
                                                            menuAdminBool = false;

                                                            break;
                                                        // Изменение купюр
                                                        case 1:
                                                            editBanknotes = Money.MenuEditBanknotesBankomat();
                                                            if (editBanknotes == 0) { editBanknotes = 0; }
                                                            else if (editBanknotes == 1) { editBanknotes = 2; }
                                                            else if (editBanknotes == 2) { editBanknotes = 3; }
                                                            else if (editBanknotes == 3) { editBanknotes = 4; }


                                                            menuAdminBool = false;
                                                            break;
                                                        // Изменение Rub
                                                        case 2:
                                                            editBanknotes = Money.MenuEditBanknotesRubUsdEur("rub");
                                                            if (editBanknotes == 0) { editBanknotes = 1; }
                                                            else if (editBanknotes == 1) { Money.EditBanknotesRubUsdEur("rub"); }


                                                            menuAdminBool = false;
                                                            break;
                                                        // Изменение Usd
                                                        case 3:
                                                            editBanknotes = Money.MenuEditBanknotesRubUsdEur("usd");
                                                            if (editBanknotes == 0) { editBanknotes = 1; }
                                                            else if (editBanknotes == 1) { Money.EditBanknotesRubUsdEur("usd"); }


                                                            menuAdminBool = false;
                                                            break;
                                                        // Изменение Eur
                                                        case 4:
                                                            editBanknotes = Money.MenuEditBanknotesRubUsdEur("eur");
                                                            if (editBanknotes == 0) { editBanknotes = 1; }
                                                            else if (editBanknotes == 1) { Money.EditBanknotesRubUsdEur("eur"); }


                                                            menuAdminBool = false;
                                                            break;
                                                    }
                                                }
                                                break;
                                        }
                                    }
                                    break;

                                // НАСТРОЙКИ БАНКОМАТА
                                case 4:
                                    menuSettingsBankomat = true;
                                    settingsBankomat = 1;
                                    while (menuSettingsBankomat == true)
                                    {
                                        switch (settingsBankomat)
                                        {
                                            // Выход из изменения настроек банкомата
                                            case 0:
                                                menuSettingsBankomat = false;
                                                menuAdminBool = true;
                                                menuAdmin = 1;
                                                break;

                                            case 1:
                                                MenuAdministrator.WellcomeMenuSettings();
                                                settingsBankomat = Security.EnterMenu(1, 4, 1, 1);
                                                break;

                                            case 2:
                                                settingsBankomat = SettingsMenuBankomat.AdminCode();
                                                if(settingsBankomat == 0) { settingsBankomat = 1; }
                                                break;

                                            case 3:
                                                settingsBankomat = SettingsMenuBankomat.PathSaveCard();
                                                if (settingsBankomat == 0) { settingsBankomat = 1; }
                                                break;

                                            case 4:
                                                settingsBankomat = SettingsMenuBankomat.PathPrintBalance();
                                                if (settingsBankomat == 0) { settingsBankomat = 1; }
                                                break;


                                        }

                                    }

                                    break;
                            }
                        }
                        break;

                    // Выбор карты
                    case 2:
                        numberCard = MainMenu.ChoiceCard();
                        if (numberCard == -1) { menu = 1; }
                        else if (numberCard == -2) { program = false; break; }
                        else { menu = 3; }


                        break;

                    // Приветствие, ввод пинкода.
                    case 3:
                        menu = MainMenu.PinkodeEnter(securyAdminPin, numberCard);
                        if (menu == -1) { menu = 0; }
                        else if(menu == 0) { menu = 1; }
                        else if (menu == 1) { menu = 4; }
                        else if (menu == -3) { menu = 2; }
                        Console.Clear();
                        break;

                    // Главное меню
                    case 4:
                        ScreenMessages.WellcomeMainMenu();
                        ScreenMessages.MainMenu();
                        menu = Security.EnterMenu(0, 3, 4, 0);
                        if (menu == 0) { menu = 2; }
                        else if(menu == 1) { menu = 5; }
                        else if (menu == 2) { menu = 6; }
                        else if (menu == 3) { menu = 7; }
                        break;
                    
                    // Вывод баланса карты
                    case 5:

                        MainMenu.BalanceCardMenu();
                        menuMainBalance = Security.EnterMenu(1, 2, 0, 0);
                        if(menuMainBalance == 0) { menu = 4; }
                        menuMainBalanceBool = true;

                        
                        while (menuMainBalanceBool == true)
                        {
                            
                            switch (menuMainBalance)
                            {
                                case 0:

                                    menu = 4;
                                    menuMainBalanceBool = false;

                                    break;

                                case 1:

                                    MainMenu.BalanceCard(numberCard);
                                    menuMainBalance = Security.EnterMenu(0, 0, 1, 0);

                                    break;

                                case 2:

                                    MainMenu.BalanceCardPrint(numberCard);
                                    menuMainBalance = 0;

                                    break;
                            }
                        }


                        break;

                    // Снятие наличных
                    case 6:

                        MainMenu.CashWithdravalMenu();
                        menuMainCashWithdraval = Security.EnterMenu(1, 2, 0, 0);
                        if (menuMainCashWithdraval == 0) { menu = 4; }
                        menuMainCashWithdravalBool = true;
                        while (menuMainBalanceBool == true)
                        {

                            switch (menuMainCashWithdraval)
                            {
                                case 0:

                                    menu = 4;
                                    menuMainBalanceBool = false;

                                    break;

                                case 1:

                                    Money.CashWithdravalWithExchange();
                                    

                                    break;

                                case 2:

                                    MainMenu.BalanceCardPrint(numberCard);
                                    menuMainBalance = 0;

                                    break;
                            }
                        }


                        break;










                }







            }



        }
    }
}
