using System;

namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool program = true;
            int menu = 1;
            int attempt = 1;
            while (program == true)
            {
                switch (menu)
                {
                        // Выход из программы
                    case 0: 
                        ScreenMessages.MisstakePincode();
                        program = false;
                        break;

                        // Приветсвие, ввод пинкода.
                    case 1:
                        
                        ScreenMessages.Wellcome();
                        ScreenMessages.EnterPincode();
                        menu = Security.EnterPinkode(1, 2, 0, attempt);
                        attempt++; 
                        Console.Clear();
                        break;
                    
                        // Главное меню
                    case 2:
                        ScreenMessages.WellcomeMainMenu();
                        ScreenMessages.MainMenu();

                        Console.ReadKey();  
                        break;










                }







            }



        }
    }
}
