using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Bankomat
{
    internal class MainMenu
    {
        public static int ChoiceCard()
        {
            string? parth;
            bool readCard = true;
            int enterInt = 0;
            int attemp = 0;
            string securyAdminPin;

            using (ApplicationContext db = new ApplicationContext())
            {
                var securyCodeMenu = db.SettingsBankomat.ToList();
                securyAdminPin = securyCodeMenu[0].securyCode;
                
                var pathCard = db.SettingsBankomat.ToList();
                parth = pathCard[0].pathCards;
            }

            

            while (readCard == true)
            {
                Console.Clear();
                Console.WriteLine("\tДобро пожаловать в прогрумму 'БАНКОМАТ'");
                DateTime now = DateTime.Now;
                Console.WriteLine($"\t    Сегодня {now}\n");
                Console.WriteLine("\tВыберите карту и вставьте в банкомат\n");

                if (File.Exists(parth) == false)
                {
                    Cards.CreateCard();
                }

                string[] textStrings = File.ReadAllLines(parth);
                Console.WriteLine("---------------------------------------------------");
                string[] textString;
                int counter = 0;
                for (int i = 0; i < textStrings.Length; i++)
                {
                    counter = i + 1;
                    textString = textStrings[i].Split(new char[] { '/' });
                    for (int j = 0; j < textString.Length; j++)
                    {


                        Console.Write($"\nКарта № {i + 1}\tИмя владельца карты: {textString[0]}\n");
                        Console.WriteLine("---------------------------------------------------");
                        break;


                    }
                }
                Console.WriteLine("\n\nВыход из программы\t\t\t\t- 0");
                Console.WriteLine("\nВаш выбор:");
                attemp++;
                string enter = Console.ReadLine();
                bool enterBool = Security.NumberCheckInt(enter);
                
                
                if (enter == "") { enterInt = -2; readCard = false; }
                else if (enter == securyAdminPin) { enterInt = -1; readCard = false; }
                else if (enterBool == true & enter != securyAdminPin)
                {
                    enterInt = Convert.ToInt32(enter);
                    if (enterInt == 0) { enterInt = -2; readCard = false; }
                    if (enterInt <= counter) { readCard = false; }
                    else if (enterInt > counter & attemp == 3) { enterInt = -2; readCard = false; };
                }
                else if (attemp == 3 & enter != securyAdminPin) { enterInt = -2; readCard = false; };
            }
            Console.Clear();
            return enterInt;


        }

        public static int PinkodeEnter(string securyAdminPin, int numberCard)
        {
            string? text;
            string? pincode;
            int enterInt = 0;
            int attempt = 1;
            bool attemptBool = true;
            bool intBool = true;
            string? parth;
            
            using (ApplicationContext db = new ApplicationContext())
            {
                var pathCard = db.SettingsBankomat.ToList();
                parth = pathCard[0].pathCards;
            }

            string[] textStrings = File.ReadAllLines(parth);
            string[] textString;
            
           
            pincode = (textStrings[numberCard - 1].Split(new char[] { '/' }))[2];
           
            

            while (attemptBool == true)
            {
                Console.WriteLine("\n\n\n\t\t\tВведите пинкод");
                text = Console.ReadLine();

                if (attempt == 3) { enterInt = -1; attemptBool = false; }

                else if (text == securyAdminPin) { enterInt = 0; attemptBool = false; }

                else if (text == pincode) { enterInt = 1; attemptBool = false; }

                else if (text == "") { enterInt = -3; attemptBool = false; }

                else if(text != securyAdminPin | text != pincode)
                {
                    ScreenMessages.MessageFlicker(4, 3, "Неверно введен пинкод", 450, 3);
                }
                attempt++;

                Console.Clear();
            }

            return enterInt;
        }

        public static void BalanceCardMenu()
        {

            Console.WriteLine("\nВернуться назад\t\t\t\t- 0");
            Console.WriteLine("Вывести баланс карты на экран\t\t- 1");
            Console.WriteLine("Распечатать чек с балансом карты\t- 2");
           
            



        }

        public static void BalanceCard(int numberCard)
        {
            string? parth;
            using (ApplicationContext db = new ApplicationContext())
            {
                var pathCard = db.SettingsBankomat.ToList();
                parth = pathCard[0].pathCards;
            }
            string? moneyRub;
            string? moneyUsd;
            string? moneyEur;

            string? text;
            string? pincode;
            


            string[] textStrings = File.ReadAllLines(parth);
            string[] textString;
            

            moneyRub = (textStrings[numberCard - 1].Split(new char[] { '/' }))[3];
            moneyUsd = (textStrings[numberCard - 1].Split(new char[] { '/' }))[4];
            moneyEur = (textStrings[numberCard - 1].Split(new char[] { '/' }))[5];

            Console.WriteLine("\n\n\t\t\tБаланс карты:");
            Console.WriteLine($"\n\tСумма рублей:\t\t\t{moneyRub} руб\n");
            Console.WriteLine($"\n\tСумма dollars:\t\t\t{moneyUsd} usd\n");
            Console.WriteLine($"\n\tСумма euro:\t\t\t{moneyEur} eur\n\n");
            Console.WriteLine("\n\nВернуться назад\t\t\t\t- 0");
          


        }


        public static void BalanceCardPrint(int numberCard)
        {
            string? parth;
            string? parthPrintBalance;
            using (ApplicationContext db = new ApplicationContext())
            {
                var pathCard = db.SettingsBankomat.ToList();
                var pathPrint = db.SettingsBankomat.ToList();

                parth = pathCard[0].pathCards;
                parthPrintBalance = pathPrint[0].parthPrintBalanceCard;
            }
            string? moneyRub;
            string? moneyUsd;
            string? moneyEur;

            string[] textStrings = File.ReadAllLines(parth);
            string[] textString;

            moneyRub = (textStrings[numberCard - 1].Split(new char[] { '/' }))[3];
            moneyUsd = (textStrings[numberCard - 1].Split(new char[] { '/' }))[4];
            moneyEur = (textStrings[numberCard - 1].Split(new char[] { '/' }))[5];

            ScreenMessages.MessageLoading("Печать чека", 50, "$", 70);
           

            DateTime now = DateTime.Now;
            StreamWriter writer = new StreamWriter(parthPrintBalance, false);
            writer.WriteLine($"\n\n\t   Баланс карты на {now}:\n\n\tСумма рублей:\t\t\t{moneyRub} руб\n\n\tСумма dollars:\t\t\t{moneyUsd} usd\n\n\tСумма euro:\t\t\t{moneyEur} eur\n\n");
            writer.Close();

            ScreenMessages.MessageFlicker(4, 3, "Чек распечатан!", 500, 2);
            Console.Clear();
            
            System.Diagnostics.Process txt = new System.Diagnostics.Process();
            txt.StartInfo.FileName = "notepad.exe";
            txt.StartInfo.Arguments = parthPrintBalance;
            txt.Start();





        }

        public static void CashWithdravalMenu()
        {
            Console.WriteLine("Меню выдачи наличных\n\n");
            Console.WriteLine("Вернуться назад\t\t\t\t- 0");
            Console.WriteLine("Снять наличные с разменом\t\t- 1");
            Console.WriteLine("Снять наличные без размена\t\t- 2");

        }

    }
}
