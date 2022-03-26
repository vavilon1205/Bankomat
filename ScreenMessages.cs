﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class ScreenMessages
    {
        public static void ChoiceCard()
        {
            
            Console.WriteLine("Выберите карту и вставьте в банкомат");
        }
        public static void Wellcome()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"Добро пожаловать в банкомат\nСегодня {now}");
        }
        public static void WellcomeMainMenu()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"Добро пожаловать в главное меню\nСегодня {now}");
        }
        public static void EnterPincode()
        {

            Console.WriteLine("\nВведите пинкод");
        }
        public static void MisstakePincode()
        {
            Console.WriteLine("\nПинкод введен неверно больше 3-х раз!\nКарта заблокированна!\nОбратитесь в отделение банка.");

        }
        public static void MainMenu()
        {
            Console.WriteLine("\nУзнать баланс\t\t\t\t- 1\nСнять наличные\t\t\t\t- 2\nВнести наличные\t\t\t\t- 3\nПрервать операцию и вернуть карту\t- 4");
        }


        // Скролл загрузки с выборос сообщения и времени
        public static void MessageLoading(string message, int time, string symbol, int lenght)
        {
            Console.Clear();
            Console.WriteLine($"\t\t\t{message}");
            Random rnd = new Random();
            int randomTime = rnd.Next(0, time);
            for (int i = 0; i < lenght; i++)
            {
                Console.Write(symbol);
                Thread.Sleep(randomTime);
            }
            Console.Clear();
        }

        // Мерцающее сообщение
        public static void MessageFlicker(int n, int tab, string message, int time, int flicker)
        {
            for (int i = 0; i < flicker; i++)
            {
                Console.Clear();
                Console.WriteLine(string.Concat(Enumerable.Repeat("\n", n)));
                Console.Write(string.Concat(Enumerable.Repeat("\t", tab)) + message);
                Thread.Sleep(time);
                Console.Clear();
                Thread.Sleep(time);
            }
        }



    }
}
