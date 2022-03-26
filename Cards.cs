using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class Cards
    {
        // Меню создания карт
        public static void WellcomeMenuCreateCards()
        {

            Console.WriteLine("Меню создания карт\n");
            Console.WriteLine("Выход из меню\t\t\t\t - 0");
            Console.WriteLine("Создание карт\t\t\t\t - 1");
            Console.WriteLine("Редактирование карт\t\t\t - 2");
        }


        // Меню пути хранения карт
        public static void DirectoryCardMessageMenu()
        {
            Console.WriteLine("Путь хранения карт по умолчанию:\n");
            Console.WriteLine(@"E:\Programming\C# projects\Bankomat\StorageCards");
            Console.WriteLine("\nОставить путь директории прежним и выйти назад\t - 0");
            Console.WriteLine("Изменить путь директории\t\t\t - 1");
        }


        // Создание пути хранения карт
        public static void CreateDirectoryCard()
        {
            Console.WriteLine("Укажите путь директории:\n");
            string path = Console.ReadLine();
            string pathDefault = @"E:\Programming\C# projects\Bankomat\StorageCards";
            if (path.Length == 0)
            {
                Console.Clear();
                DirectoryCardMessageMenu();
            }
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (!dir.Exists)
                {
                    dir.Create();
                    Console.Clear();
                    Console.WriteLine("Директория создана");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Некорректный ввод!");
                Thread.Sleep(3000);
                Console.Clear();


            }

            DirectoryCardMessageMenu();
        }



        public static void CreateCard()
        {

            FileStream creadCard = new FileStream("Cards.txt", FileMode.OpenOrCreate);
            creadCard.Close();

        }

        public static int WriteCard(string path, int menuReturn)
        {
            if (path == null)
            {
                path = "Cards.txt";
            }

            string numberCardString = "";
            char[] genNumberCard = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            Random rnd = new Random();
            for (int i = 0; i < 16; i++)
            {
                numberCardString += genNumberCard[rnd.Next(0, 10)];
            }
            long numberCardLong = long.Parse(numberCardString);
            string numberCardFormat = string.Format("{0:####-####-####-####}", numberCardLong);

            Console.WriteLine("Введите внимательно данные для создания новой карты!\n\n");
            Console.WriteLine("Имя владельца карты:");
            string name = Console.ReadLine();
            if (name == "")
            {
                ScreenMessages.MessageFlicker(4, 3, "Некорректный ввод данных", 500, 3);
                return menuReturn;
            }
            Console.WriteLine($"\nНомер Вашей карты: {numberCardFormat}");
            Console.WriteLine("\nЧетырехзначный пинкод:");
            string pinCode = Console.ReadLine();
            bool pinCOdebool = Security.NumberEnterPinCodeWriteCard(pinCode);
            if (pinCOdebool == false)
            {
                ScreenMessages.MessageFlicker(4, 3, "Некорректный ввод данных", 500, 3);
                return menuReturn;
            }
            Console.WriteLine("\nСумма Rub:");
            string rub = Console.ReadLine();
            if (rub == "") { rub = "0"; };
            bool rubBool = Security.NumberCheckDecimal(rub);
            if (rubBool == false)
            {
                ScreenMessages.MessageFlicker(4, 3, "Некорректный ввод данных", 500, 3);
                return menuReturn;
            }

            Console.WriteLine("\nСумма Usd:");
            string usd = Console.ReadLine();
            if (usd == "") { usd = "0"; };
            bool usdBool = Security.NumberCheckDecimal(usd);
            if (usdBool == false)
            {
                ScreenMessages.MessageFlicker(4, 3, "Некорректный ввод данных", 500, 3);
                return menuReturn;
            }
            Console.WriteLine("\nСумма Eur:");
            string eur = Console.ReadLine();
            if (eur == "") { eur = "0"; };
            bool eurBool = Security.NumberCheckDecimal(eur);
            if (eurBool == false)
            {
                ScreenMessages.MessageFlicker(4, 3, "Некорректный ввод данных", 500, 3);
                return menuReturn;
            }

            Console.Clear();
            Console.WriteLine("Проверьте внимательно введенные данные!\n\n");
            Console.WriteLine($"Имя владельца карты: {name}\nНомер Вашей карты: {numberCardFormat}\nPinCode: {pinCode}\nСумма рублей {rub} руб\nСумма dollars: {usd} usd\nСумма euro: {eur} eur\n");
            Console.WriteLine("\n\nОтмена операции\t\t\t- 0");
            Console.WriteLine("Продолжить\t\t\t- 1");
            Console.WriteLine("\nВаш выбор:");
            string enter = Console.ReadLine();

            if (enter == "1")
            {
                string cardText = $"{name}/{numberCardString}/{pinCode}/{rub}/{usd}/{eur}";
                StreamWriter writer = new StreamWriter(path, true);
                writer.WriteLine(cardText);
                writer.Close();
                ScreenMessages.MessageLoading("Запись", 50, "$", 70);
                ScreenMessages.MessageFlicker(4, 3, "Запись прошла успешна!", 500, 3);
                return menuReturn;
            }
            else if (enter == "0" | enter == "")
            {
                ScreenMessages.MessageFlicker(4, 3, "Операция отменена!", 500, 3);
                return menuReturn;
            }
            else
            {
                ScreenMessages.MessageFlicker(4, 3, "Некорректный ввод данных", 500, 3);
                return menuReturn;
            }

        }

        public static int ReadCards(string path)
        {
            DeleteNullLines(path);
            int enterInt = 0;
            bool readCard = true;

            while (readCard == true)
            {
                Console.Clear();
                if (File.Exists("Cards.txt") == false)
                {
                    Cards.CreateCard();
                }

                string[] textStrings = File.ReadAllLines("Cards.txt");
                Console.WriteLine("\t\t\tСписок карт\n\n");
                Console.WriteLine("---------------------------------------------------");
                string[] textString;
                int counter = 0;
                for (int i = 0; i < textStrings.Length; i++)
                {
                    counter = i + 1;
                    textString = textStrings[i].Split(new char[] { '/' });
                    for (int j = 0; j < textString.Length; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                Console.WriteLine($"\nПорядковый номер:\t\t{i + 1}\n\nИмя владельца карты:\t\t{textString[0]}\n");
                                break;
                            case 1:
                                long numberCardLong = long.Parse(textString[1]);
                                string numberCardFormat = string.Format("{0:####-####-####-####}", numberCardLong);
                                Console.WriteLine($"Номер карты:\t\t\t{numberCardFormat}\n");
                                break;
                            case 2:
                                Console.WriteLine($"ПинКод:\t\t\t\t{textString[2]}\n");
                                break;
                            case 3:
                                Console.WriteLine($"Сумма рублей:\t\t\t{textString[3]} руб\n");
                                break;
                            case 4:
                                Console.WriteLine($"Сумма dollars:\t\t\t{textString[4]} usd\n");
                                break;
                            case 5:
                                Console.WriteLine($"Сумма euro:\t\t\t{textString[5]} eur\n\n");
                                Console.WriteLine("---------------------------------------------------");
                                break;
                        }
                    }
                }
                Console.WriteLine("\n\nВернуться назад\t\t\t\t\t\t- 0");
                Console.WriteLine("Для редактирования введите порядковый номер карты\t");
                string enter = Console.ReadLine();
                if (enter == "")
                {
                    enterInt = 0;
                    readCard = false;
                }
                bool enterBool = Security.NumberCheckInt(enter);
                if (enterBool == true)
                {
                    enterInt = Convert.ToInt32(enter);
                    if (enterInt <= counter) { readCard = false; }
                }
            }
            return enterInt;
        }

        static void DeleteNullLines(string parth)
        {
            string[] textStrings = File.ReadAllLines(parth);
            StreamWriter writer = new StreamWriter(parth);
            foreach (string line in textStrings)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    writer.WriteLine(line);
                }
            }
            writer.Close();
        }

        public static int EditDataCards(string parth, int numberCard)
        {

            int enterInt = 0;
            bool readCard = true;

            while (readCard == true)
            {
                Console.Clear();
                if (File.Exists(parth) == false)
                {
                    Cards.CreateCard();
                }

                string[] textStrings = File.ReadAllLines(parth);
                Console.WriteLine("\t\t\tДанные карты\n");
                Console.WriteLine("---------------------------------------------------");
                string[] textString;

                for (int i = 0; i < textStrings.Length; i++)
                {
                    if (i == numberCard - 1)
                    {
                        textString = textStrings[i].Split(new char[] { '/' });
                        for (int j = 0; j < textString.Length; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    Console.WriteLine($"\n\nИмя владельца карты:\t\t{textString[0]}\n");
                                    break;
                                case 1:
                                    long numberCardLong = long.Parse(textString[1]);
                                    string numberCardFormat = string.Format("{0:####-####-####-####}", numberCardLong);
                                    Console.WriteLine($"Номер карты:\t\t\t{numberCardFormat}\n");
                                    break;
                                case 2:
                                    Console.WriteLine($"ПинКод:\t\t\t\t{textString[2]}\n");
                                    break;
                                case 3:
                                    Console.WriteLine($"Сумма рублей:\t\t\t{textString[3]} руб\n");
                                    break;
                                case 4:
                                    Console.WriteLine($"Сумма dollars:\t\t\t{textString[4]} usd\n");
                                    break;
                                case 5:
                                    Console.WriteLine($"Сумма euro:\t\t\t{textString[5]} eur\n\n");
                                    Console.WriteLine("---------------------------------------------------");
                                    break;
                            }
                        }

                    }

                }
                Console.WriteLine("\n\nВернуться назад\t\t\t\t - 0\nИзменить данные карты\t\t\t - 1\nУдалить карту\t\t\t\t - 2");
                Console.WriteLine();
                string enter = Console.ReadLine();
                bool enterBool = Security.NumberCheckInt(enter);
                if (enter == "")
                {
                    enterInt = 0;
                    readCard = false;
                }
                else if (enterBool == true & (enter == "0" | enter == "1"))
                {
                    enterInt = Convert.ToInt32(enter);
                    readCard = false;
                }
                else if (enterBool == true & enter == "2")
                {
                    Console.Clear();
                    Console.WriteLine("\n\nВы действительно хотите удалить карту?\n\nОтмена\t\t\t\t\t - 0\nУдалить карту\t\t\t\t - 1");
                    enter = Console.ReadLine();

                    if (enter == "0" | enter == "")
                    {
                        ScreenMessages.MessageFlicker(4, 3, "Отмена операции", 500, 3);
                        break;
                    }
                    else if (enter == "1")
                    {
                        DeleteCards(parth, numberCard);
                        DeleteNullLines(parth);
                        ScreenMessages.MessageLoading("Удаление карты", 50, "$", 70);
                        ScreenMessages.MessageFlicker(4, 3, "Удаление карты прошло успешно!", 500, 3);
                        enterInt = 0;
                        readCard = false;
                    }
                    else 
                    {
                        ScreenMessages.MessageFlicker(4, 3, "Отмена операции", 500, 3);
                        break; 
                    }

                }


            }
            return enterInt;
        }

        public static int RenameDataCards(string parth, int menuReturn, int numberCard)
        {
            Console.Clear();
            string text = "";
            int number = 0;
            bool examination;
            bool switchExamination = true;
            bool misstake = false;

            string[] textStrings = File.ReadAllLines(parth);
            Console.WriteLine("\t\t\tИзменение данных карты\n\n");
            Console.WriteLine("---------------------------------------------------");
            string[] textString;
            int i = numberCard - 1;

            textString = textStrings[i].Split(new char[] { '/' });


            for (int j = 0; j < textString.Length; j++)
            {
                switchExamination = true;
                if (j == 0) { number = 0; }
                else if (j == 1) { continue; }
                else if (j == 2) { number = 1; }
                else if (j == 3) { number = 2; }
                else if (j == 4) { number = 3; }
                else if (j == 5) { number = 4; }


                while (switchExamination == true)
                {
                    switch (number)
                    {
                        case 0:
                            Console.WriteLine($"\n\nИмя владельца карты:\t\t{textString[0]}\n");
                            Console.WriteLine("\n\nВведите новое имя владельца карты или нажмите Enter - оставить имя прежним\n");
                            text = Console.ReadLine();
                            if (text != "")
                            {
                                textString[j] = text;
                            }
                            Console.Clear();
                            switchExamination = false;
                            break;

                        case 1:
                            Console.Clear();
                            Console.WriteLine("\t\t\tИзменение данных карты\n\n");
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine($"\n\nПинКод карты:\t\t\t\t{textString[2]}\n");
                            Console.WriteLine("\n\nВведите новый пинКод\tEnter - оставить ПинКод прежним\n");
                            string pinCode = Console.ReadLine();
                            if (pinCode == "")
                            {
                                switchExamination = false;
                                break;
                            }
                            bool pinCOdebool = Security.NumberEnterPinCodeWriteCard(pinCode);
                            if (pinCOdebool == false)
                            {
                                ScreenMessages.MessageFlicker(4, 3, "Некорректный ввод данных", 500, 3);

                            }
                            else if (pinCOdebool == true)
                            {
                                textString[j] = pinCode;
                                switchExamination = false;
                            }
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("\t\t\tИзменение данных карты\n\n");
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine($"\n\nСумма рублей:\t\t\t{textString[3]} руб\n");
                            Console.WriteLine("\n\nВведите новый значение суммы рублей\tEnter - оставить сумму прежней\n");
                            string rub = Console.ReadLine();
                            if (rub == "")
                            {
                                switchExamination = false;
                                break;
                            }
                            bool rubBool = Security.NumberCheckDecimal(rub);
                            if (rubBool == false)
                            {
                                ScreenMessages.MessageFlicker(4, 3, "Некорректный ввод данных", 500, 3);

                            }
                            else if (rubBool == true)
                            {
                                textString[j] = rub;
                                switchExamination = false;
                            }
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("\t\t\tИзменение данных карты\n\n");
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine($"\n\nСумма dollars:\t\t\t{textString[4]} usd\n");
                            Console.WriteLine("\n\nВведите новый значение суммы dollars\tEnter - оставить сумму прежней\n");
                            string usd = Console.ReadLine();
                            if (usd == "")
                            {
                                switchExamination = false;
                                break;
                            }
                            bool usdBool = Security.NumberCheckDecimal(usd);
                            if (usdBool == false)
                            {
                                ScreenMessages.MessageFlicker(4, 3, "Некорректный ввод данных", 500, 3);

                            }

                            else if (usdBool == true)
                            {
                                textString[j] = usd;
                                switchExamination = false;
                            }
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("\t\t\tИзменение данных карты\n\n");
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine($"\n\nСумма euro:\t\t\t{textString[5]} eur\n\n");
                            Console.WriteLine("\n\nВведите новый значение суммы euro\tEnter - оставить сумму прежней\n");
                            string eur = Console.ReadLine();
                            if (eur == "")
                            {
                                switchExamination = false;
                                break;
                            }
                            bool eurBool = Security.NumberCheckDecimal(eur);
                            if (eurBool == false)
                            {
                                ScreenMessages.MessageFlicker(4, 3, "Некорректный ввод данных", 500, 3);
                                switchExamination = false;
                            }
                            else if (eurBool == true)
                            {
                                textString[j] = eur;
                                switchExamination = false;
                            }
                            Console.Clear();
                            switchExamination = false;
                            break;
                    }
                }
            }
            Console.Clear();
            long numberCardLong = long.Parse(textString[1]);
            string numberCardFormat = string.Format("{0:####-####-####-####}", numberCardLong);
            Console.WriteLine("Проверьте внимательно введенные данные!\n\n");
            Console.WriteLine($"Имя владельца карты: {textString[0]}\nНомер Вашей карты: {numberCardFormat}\nPinCode: {textString[2]}\nСумма рублей {textString[3]} руб\nСумма dollars: {textString[4]} usd\nСумма euro: {textString[5]} eur\n");
            Console.WriteLine("\n\nОтмена операции\t\t\t- 0");
            Console.WriteLine("Продолжить\t\t\t- 1");
            Console.WriteLine("\nВаш выбор:");
            string enter = Console.ReadLine();

            if (enter == "1")
            {
                DeleteCards(parth, numberCard);
                string cardText = $"{textString[0]}/{textString[1]}/{textString[2]}/{textString[3]}/{textString[4]}/{textString[5]}";
                textStrings = File.ReadAllLines(parth);
                var textStringsRewrite = textStrings.ToList();
                textStringsRewrite.Insert(i, cardText);
                textStrings = textStringsRewrite.ToArray();

                File.WriteAllLines(parth, textStrings);

                ScreenMessages.MessageLoading("Запись", 50, "$", 70);
                ScreenMessages.MessageFlicker(4, 3, "Запись прошла успешна!", 500, 3);
                return menuReturn;
            }
            else if (enter == "0" | enter == "")
            {
                ScreenMessages.MessageFlicker(4, 3, "Операция отменена!", 500, 3);
                return menuReturn;
            }
            else
            {
                ScreenMessages.MessageFlicker(4, 3, "Некорректный ввод данных", 500, 3);
                return menuReturn;
            }






        }

        static void DeleteCards(string path, int numberCart)
        {
            string line;
            string[] textStrings = File.ReadAllLines(path);
            //string[] newTextStrings;
            line = textStrings[numberCart - 1];
            var textStringsRemove = textStrings.ToList();
            textStringsRemove.Remove(line);
            textStrings = textStringsRemove.ToArray();
            File.WriteAllLines(path, textStrings);
        }
    }
}
