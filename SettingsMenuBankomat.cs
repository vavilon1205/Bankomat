using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class SettingsMenuBankomat
    {

        public static int AdminCode()
        {
            string? enter;
            bool attempt = true;
            int number = 0;

            using (ApplicationContext db = new ApplicationContext())
            {  
                var securyCodeMenu = db.SettingsBankomat.ToList();

                while (attempt == true)
                {

                    Console.WriteLine("Установка кода входа в меню администратора\n\n");
                    Console.WriteLine($"Установленный код - {securyCodeMenu[0].securyCode}\n\n");

                    Console.WriteLine("Изменить код\t\t\t - 1\nВыход в предыдущее меню\t\t - 0");

                    enter = Security.EnterInformation();
                    if (enter == "" | enter == "0") { attempt = false; number = 0; }

                    else if (enter == "1") { attempt = false; number = 1; }
                    
                    Console.Clear();
                }
            }

            if (number == 1)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var securyCodeMenu = db.SettingsBankomat.ToList();
                    Console.Clear();
                    Console.WriteLine("Введите новый код входа в меню администратора\n\n");
                    enter = Console.ReadLine();
                    if (enter == "") { enter = "000"; }
                    securyCodeMenu[0].securyCode = enter;
                    db.SaveChanges();
                    Console.Clear();
                    SettingsMenuBankomat.AdminCode();
                }
            }
            number = 0;
            return number;            
        }

        public static int PathSaveCard()
        {
            string? enter;
            bool attempt = true;
            int number = 0;

            using (ApplicationContext db = new ApplicationContext())
            {
                var pathCard = db.SettingsBankomat.ToList();

                while (attempt == true)
                {

                    Console.WriteLine("Установка дирректории создания хранилища карт\n\n");
                    Console.WriteLine($"Установленный путь - {pathCard[0].pathCards}\n\n");

                    Console.WriteLine("Изменить путь\t\t\t - 1\nВыход в предыдущее меню\t\t - 0");

                    enter = Security.EnterInformation();
                    if (enter == "" | enter == "0") { attempt = false; number = 0; }

                    else if (enter == "1") { attempt = false; number = 1; }

                    Console.Clear();
                }
            }

            if (number == 1)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var pathCard = db.SettingsBankomat.ToList();
                    Console.Clear();
                    Console.WriteLine("Введите новый путь дирректории создания хранилища карт\n\n");
                    enter = Console.ReadLine();
                    if(enter == "") { enter = "Cards.txt"; }

                    else if(enter.Contains("Cards.txt") == false)
                    {
                        enter += "Cards.txt";
                    }
                    
                    pathCard[0].pathCards = enter;
                    db.SaveChanges();
                   
                }

                try
                {
                    FileStream creadCard = new FileStream(enter, FileMode.OpenOrCreate);
                    creadCard.Close();
                }
                catch (Exception)
                {

                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var pathCard = db.SettingsBankomat.ToList();
                        pathCard[0].pathCards = "Cards.txt";
                        db.SaveChanges();
                    }

                }
                
                Console.Clear();
                SettingsMenuBankomat.PathSaveCard();

            }
            number = 0;
            return number;
        }

        public static int PathPrintBalance()
        {
            string? enter;
            bool attempt = true;
            int number = 0;

            using (ApplicationContext db = new ApplicationContext())
            {
                var pathCard = db.SettingsBankomat.ToList();

                while (attempt == true)
                {

                    Console.WriteLine("Установка пути сохранения чека баланса счета\n\n");
                    Console.WriteLine($"Установленный путь - {pathCard[0].parthPrintBalanceCard}\n\n");

                    Console.WriteLine("Изменить путь\t\t\t - 1\nВыход в предыдущее меню\t\t - 0");

                    enter = Security.EnterInformation();
                    if (enter == "" | enter == "0") { attempt = false; number = 0; }

                    else if (enter == "1") { attempt = false; number = 1; }

                    Console.Clear();
                }
            }

            if (number == 1)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var pathCard = db.SettingsBankomat.ToList();
                    Console.Clear();
                    Console.WriteLine("Введите новый путь сохранения чека баланса счета без указания названия файла\n\nEnter - путь по умолчанию(Рабочий стол)\n\n");
                    enter = Console.ReadLine();
                    if (enter == "") { enter = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\BalanceCard.txt"; }

                    else if (enter.Contains("BalanceCard.txt") == false)
                    {
                        enter += "BalanceCard.txt";
                    }

                    pathCard[0].parthPrintBalanceCard = enter;
                    db.SaveChanges();

                }

                try
                {
                    FileStream creadCard = new FileStream(enter, FileMode.OpenOrCreate);
                    creadCard.Close();
                    File.Delete(enter);

                }
                catch (Exception)
                {

                    using (ApplicationContext db = new ApplicationContext())
                    {
                        var pathCard = db.SettingsBankomat.ToList();
                        pathCard[0].parthPrintBalanceCard = "BalanceCard.txt";
                        db.SaveChanges();
                    }

                }

                Console.Clear();
                SettingsMenuBankomat.PathPrintBalance();

            }
            number = 0;
            return number;
        }





    }














}