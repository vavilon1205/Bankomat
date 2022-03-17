using System;

namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int menu = 0;
            while (true)
            {
                switch (menu)
                {
                    case 0:
                        ScreenMessages.Wellcome();
                        ScreenMessages.EnterPincode();
                        menu = Security.EnterPinkode(0, 1); 

                        break;

                    case 1:
                        Console.WriteLine("Ok");
                        Console.ReadKey();  
                        break;










                }







            }



        }
    }
}
