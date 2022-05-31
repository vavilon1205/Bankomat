namespace Bankomat
{
    internal class Money
    {
        // Выводит информацию о количестве купюр в банкомате
        public static void InformationBanknotesBankomat()
        {
            
            using (ApplicationContext db = new ApplicationContext())
            {
                var banknotesRub = db.Rub.ToList();
                Console.WriteLine("Информация о купюрах Rub:");
                foreach (var r in banknotesRub)
                {
                    Console.WriteLine($"'100'\t - {r.hundred}\n'200'\t - {r.twoHundred}\n'500'\t - {r.fiveHundred}\n'1000'\t - {r.thousand}\n'2000'\t - {r.twoThousand}\n'5000'\t - {r.fiveThousand}\n");
                }

                var banknotesUsd = db.Usd.ToList();
                Console.WriteLine("Информация о купюрах Usd:");
                foreach (var u in banknotesUsd)
                {
                    Console.Write($"'1'\t - {u.one}\n'2'\t - {u.two}\n'5'\t - {u.five}\n'10'\t - {u.ten}\n'20'\t - {u.twenty}\n'50'\t - {u.fifty}\n'100'\t - {u.hundred}\n\n");
                }

                var banknotesEur = db.Eur.ToList();
                Console.WriteLine("Информация о купюрах Eur:");
                foreach (var e in banknotesEur)
                {
                    Console.Write($"'5'\t - {e.five}\n'10'\t - {e.ten}\n'20'\t - {e.twenty}\n'50'\t - {e.fifty}\n'100'\t - {e.hundred}\n'200'\t - {e.twoHundred}\n'500'\t - {e.fiveHundred}\n");
                }
                Console.WriteLine("\nВернуться назад\t\t\t - 0");

            }
        }

        // Меню пополнения банкнот
        public static int MenuEditBanknotesBankomat()
        {
            string text = "";

            Console.WriteLine("Пополнение банкнотами\n");
            Console.WriteLine("Вернуться назад\t\t\t - 0\nИзменение Rub\t\t\t - 1\nИзменение Usd\t\t\t - 2\nИзменение Eur\t\t\t - 3");
            text = Security.EnterInformation();

            if (text == "0" | text == "")
            {
                Console.Clear();
                return 0;
            }

            else if (text == "1")
            {
                Console.Clear();
                return 1;
            }
            else if (text == "2")
            {
                Console.Clear();
                return 2;
            }
            else if (text == "3")
            {
                Console.Clear();
                return 3;
            }
            else
            {
                Console.Clear();
                return MenuEditBanknotesBankomat();
            }

        }

        // Подменю выбора изменяемой валюты
        public static int MenuEditBanknotesRubUsdEur(string rubUsdEur)
        {
            string text = "";
            string valute = "купюра с номиналом ";
            string unit = " единиц";


            using (ApplicationContext db = new ApplicationContext())
            {
                switch (rubUsdEur)
                {
                    case "rub":
                        ScreenMessages.MessageLoading("Подсчет купюр в банкомате", 50, "$", 70);
                        text = "Rub";
                        Rub test = new Rub();
                        var banknotesRub = db.Rub.ToList();
                        Console.WriteLine("Информация о купюрах Rub:\n");
                        foreach (var r in banknotesRub)
                        {
                            Console.WriteLine($"{valute}'100'   - {r.hundred}{unit}\n{valute}'200'   - {r.twoHundred}{unit}\n{valute}'500'   - {r.fiveHundred}{unit}\n{valute}'1000'  - {r.thousand}{unit}\n{valute}'2000'  - {r.twoThousand}{unit}\n{valute}'5000'  - {r.fiveThousand}{unit}\n");
                        }

                        break;

                    case "usd":
                        ScreenMessages.MessageLoading("Подсчет купюр в банкомате", 50, "$", 70);
                        text = "Usd";
                        var banknotesUsd = db.Usd.ToList();
                        Console.WriteLine("Информация о купюрах Usd:\n");
                        foreach (var u in banknotesUsd)
                        {
                            Console.Write($"{valute}'1'\t - {u.one}{unit}\n{valute}'2'\t - {u.two}{unit}\n{valute}'5'\t - {u.five}{unit}\n{valute}'10'  - {u.ten}{unit}\n{valute}'20'  - {u.twenty}{unit}\n{valute}'50'  - {u.fifty}{unit}\n{valute}'100' - {u.hundred}{unit}\n\n");
                        }
                        break;

                    case "eur":
                        ScreenMessages.MessageLoading("Подсчет купюр в банкомате", 50, "$", 70);
                        text = "eur";
                        var banknotesEur = db.Eur.ToList();
                        Console.WriteLine("Информация о купюрах Eur:\n");
                        foreach (var e in banknotesEur)
                        {
                            Console.Write($"{valute}'5'\t - {e.five}{unit}\n{valute}'10'  - {e.ten}{unit}\n{valute}'20'  - {e.twenty}{unit}\n{valute}'50'  - {e.fifty}{unit}\n{valute}'100' - {e.hundred}{unit}\n{valute}'200' - {e.twoHundred}{unit}\n{valute}'500' - {e.fiveHundred}{unit}\n");
                        }
                        break;
                }

                Console.WriteLine($"\nВернуться назад\t\t\t - 0\nИзменение {text}\t\t\t - 1");
                text = Security.EnterInformation();

                if (text == "0" | text == "") { Console.Clear(); return 0; }
                else if (text == "1") { Console.Clear(); return 1; }
                else { Console.Clear(); return MenuEditBanknotesRubUsdEur(rubUsdEur); }

            }













        }

        public static void EditBanknotesRubUsdEur(string rubUsdEur)
        {

            List<string> rubNumberList = new List<string> { "100", "200", "500", "1000", "2000", "5000" };
            List<string> usdNumberList = new List<string> { "1", "2", "5", "10", "20", "50", "100" };
            List<string> eurNumberList = new List<string> { "5", "10", "20", "50", "100", "200", "500" };

            switch (rubUsdEur)
            {
                case "rub":
                    Console.Clear();
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        Rub test = new Rub();
                        var banknotesRub = db.Rub.ToList();
                        

                        banknotesRub[0].hundred = BanknotesEdit(rubNumberList[0], banknotesRub[0].hundred);
                        banknotesRub[0].twoHundred = BanknotesEdit(rubNumberList[1], banknotesRub[0].twoHundred);
                        banknotesRub[0].fiveHundred = BanknotesEdit(rubNumberList[2], banknotesRub[0].fiveHundred);
                        banknotesRub[0].thousand = BanknotesEdit(rubNumberList[3], banknotesRub[0].thousand);
                        banknotesRub[0].twoThousand = BanknotesEdit(rubNumberList[4], banknotesRub[0].twoThousand);
                        banknotesRub[0].fiveThousand = BanknotesEdit(rubNumberList[5], banknotesRub[0].fiveThousand);

                        db.SaveChanges();

                        ScreenMessages.MessageLoading("Загрузка купюр в банкомат", 50, "$", 70);
                        ScreenMessages.MessageFlicker(4, 3, "Загрузка купюр прошла успешна!", 500, 3);
                    }

                    break;

                case "usd":

                    Console.Clear();
                    using (ApplicationContext db = new ApplicationContext())
                    {

                        Usd test = new Usd();
                        var banknotesUsd = db.Usd.ToList();


                        banknotesUsd[0].one = BanknotesEdit(usdNumberList[0], banknotesUsd[0].one);
                        banknotesUsd[0].two = BanknotesEdit(usdNumberList[1], banknotesUsd[0].two);
                        banknotesUsd[0].five = BanknotesEdit(usdNumberList[2], banknotesUsd[0].five);
                        banknotesUsd[0].ten = BanknotesEdit(usdNumberList[3], banknotesUsd[0].ten);
                        banknotesUsd[0].twenty = BanknotesEdit(usdNumberList[4], banknotesUsd[0].twenty);
                        banknotesUsd[0].fifty = BanknotesEdit(usdNumberList[5], banknotesUsd[0].fifty);
                        banknotesUsd[0].hundred = BanknotesEdit(usdNumberList[6], banknotesUsd[0].hundred);


                        db.SaveChanges();

                        ScreenMessages.MessageLoading("Загрузка купюр в банкомат", 50, "$", 70);
                        ScreenMessages.MessageFlicker(4, 3, "Загрузка купюр прошла успешна!", 500, 3);
                    }
                    break;

                case "eur":

                    Console.Clear();
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        Eur test = new Eur();
                        var banknotesEur = db.Eur.ToList();

                        banknotesEur[0].five = BanknotesEdit(eurNumberList[0], banknotesEur[0].five);
                        banknotesEur[0].ten = BanknotesEdit(eurNumberList[1], banknotesEur[0].ten);
                        banknotesEur[0].twenty = BanknotesEdit(eurNumberList[2], banknotesEur[0].twenty);
                        banknotesEur[0].fifty = BanknotesEdit(eurNumberList[3], banknotesEur[0].fifty);
                        banknotesEur[0].hundred = BanknotesEdit(eurNumberList[4], banknotesEur[0].hundred);
                        banknotesEur[0].twoHundred = BanknotesEdit(eurNumberList[5], banknotesEur[0].twoHundred);
                        banknotesEur[0].fiveHundred = BanknotesEdit(eurNumberList[6], banknotesEur[0].fiveHundred);

                        db.SaveChanges();

                        ScreenMessages.MessageLoading("Загрузка купюр в банкомат", 50, "$", 70);
                        ScreenMessages.MessageFlicker(4, 3, "Загрузка купюр прошла успешна!", 500, 3);

                    }
                    break;

            }
            Console.Clear();
        }

        private static int BanknotesEdit(string valute, int valuteValue)
        {
            Console.Clear();
            string? text;
            bool attempt = true;
            bool numberBool;
            int number = 0;
            string valuteName = "купюра с номиналом ";
            string unit = " единиц";

            while (attempt == true)
            {
                Console.Clear();
                Console.WriteLine("Купюры Rub\n");
                Console.WriteLine($"\n{valuteName}'{valute}'  - {valuteValue}{unit}\n");
                Console.WriteLine("Введите количество купюр для пополнения,\nлибо Enter - оставить количество прежним\n");
                Console.WriteLine("\nВаш ввод:");
                text = Console.ReadLine();
                numberBool = Security.NumberCheckInt(text);
                if (numberBool == false & text != "") { attempt = true; }
                else if (text == "")
                {
                    number = valuteValue;
                    attempt = false;

                }
                else
                {
                    number = Convert.ToInt32(text);
                    attempt = false;
                }
            }
            return number;



        }

        public static void CashWithdraval(string rubUsdEur)
        {

            //Console.WriteLine("\nВернуться назад\t\t\t\t- 0");
            //Console.WriteLine("Снять наличные с разменом\t\t- 1");
            //Console.WriteLine("Снять наличные без размена\t- 2");


            int enterCash;
            string? enterCashString;
            bool attemptBool = true;
            bool intBool = true;


            while (attemptBool == true)
            {
                
                Console.WriteLine("\n\n\nВведите сумму для снятия\n");
                enterCashString = Security.EnterInformation();
                intBool = Security.NumberCheckInt(enterCashString);
                if (intBool == false) { attemptBool = false; }





            }

            


            List<string> rubNumberList = new List<string> { "100", "200", "500", "1000", "2000", "5000" };
            List<string> usdNumberList = new List<string> { "1", "2", "5", "10", "20", "50", "100" };
            List<string> eurNumberList = new List<string> { "5", "10", "20", "50", "100", "200", "500" };

            switch (rubUsdEur)
            {
                case "rub":
                    Console.Clear();
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        Rub test = new Rub();
                        var banknotesRub = db.Rub.ToList();


                        banknotesRub[0].hundred = BanknotesEdit(rubNumberList[0], banknotesRub[0].hundred);
                        banknotesRub[0].twoHundred = BanknotesEdit(rubNumberList[1], banknotesRub[0].twoHundred);
                        banknotesRub[0].fiveHundred = BanknotesEdit(rubNumberList[2], banknotesRub[0].fiveHundred);
                        banknotesRub[0].thousand = BanknotesEdit(rubNumberList[3], banknotesRub[0].thousand);
                        banknotesRub[0].twoThousand = BanknotesEdit(rubNumberList[4], banknotesRub[0].twoThousand);
                        banknotesRub[0].fiveThousand = BanknotesEdit(rubNumberList[5], banknotesRub[0].fiveThousand);

                        db.SaveChanges();

                        ScreenMessages.MessageLoading("Загрузка купюр в банкомат", 50, "$", 70);
                        ScreenMessages.MessageFlicker(4, 3, "Загрузка купюр прошла успешна!", 500, 3);
                    }

                    break;

                case "usd":

                    Console.Clear();
                    using (ApplicationContext db = new ApplicationContext())
                    {

                        Usd test = new Usd();
                        var banknotesUsd = db.Usd.ToList();


                        banknotesUsd[0].one = BanknotesEdit(usdNumberList[0], banknotesUsd[0].one);
                        banknotesUsd[0].two = BanknotesEdit(usdNumberList[1], banknotesUsd[0].two);
                        banknotesUsd[0].five = BanknotesEdit(usdNumberList[2], banknotesUsd[0].five);
                        banknotesUsd[0].ten = BanknotesEdit(usdNumberList[3], banknotesUsd[0].ten);
                        banknotesUsd[0].twenty = BanknotesEdit(usdNumberList[4], banknotesUsd[0].twenty);
                        banknotesUsd[0].fifty = BanknotesEdit(usdNumberList[5], banknotesUsd[0].fifty);
                        banknotesUsd[0].hundred = BanknotesEdit(usdNumberList[6], banknotesUsd[0].hundred);


                        db.SaveChanges();

                        ScreenMessages.MessageLoading("Загрузка купюр в банкомат", 50, "$", 70);
                        ScreenMessages.MessageFlicker(4, 3, "Загрузка купюр прошла успешна!", 500, 3);
                    }
                    break;

                case "eur":

                    Console.Clear();
                    using (ApplicationContext db = new ApplicationContext())
                    {
                        Eur test = new Eur();
                        var banknotesEur = db.Eur.ToList();

                        banknotesEur[0].five = BanknotesEdit(eurNumberList[0], banknotesEur[0].five);
                        banknotesEur[0].ten = BanknotesEdit(eurNumberList[1], banknotesEur[0].ten);
                        banknotesEur[0].twenty = BanknotesEdit(eurNumberList[2], banknotesEur[0].twenty);
                        banknotesEur[0].fifty = BanknotesEdit(eurNumberList[3], banknotesEur[0].fifty);
                        banknotesEur[0].hundred = BanknotesEdit(eurNumberList[4], banknotesEur[0].hundred);
                        banknotesEur[0].twoHundred = BanknotesEdit(eurNumberList[5], banknotesEur[0].twoHundred);
                        banknotesEur[0].fiveHundred = BanknotesEdit(eurNumberList[6], banknotesEur[0].fiveHundred);

                        db.SaveChanges();

                        ScreenMessages.MessageLoading("Загрузка купюр в банкомат", 50, "$", 70);
                        ScreenMessages.MessageFlicker(4, 3, "Загрузка купюр прошла успешна!", 500, 3);

                    }
                    break;

            }
            Console.Clear();
        }



        public static void CashWithdravalWithExchange()
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                Rub test = new Rub();
                var banknotesRub = db.Rub.ToList();


               

                //db.SaveChanges();

                int banknotesIndex = 0;
                List<int> rubBank = new List <int> { 100, 200, 500, 1000, 2000, 5000 };

                List<string> rubNumberList = new List<string> { "100", "200", "500", "1000", "2000", "5000" };





                List<int> listRub = new List<int> { banknotesRub[0].hundred, banknotesRub[0].twoHundred, banknotesRub[0].fiveHundred, banknotesRub[0].thousand, banknotesRub[0].twoThousand, banknotesRub[0].fiveThousand };
                

                    
                    
                    int[] rubWithdrawal = new int[6];
                    List<int> difference = new List<int> { listRub[0], listRub[1], listRub[2], listRub[3], listRub[4], listRub[5] };
                   

                    Console.WriteLine("Введите сумму");
                    int cash = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Сумма - {cash}\n");

                    for (int i = 5; i < rubBank.Count; i--)
                    {
                        if (i >= 0 & cash >= 100)
                        {
                            if (i >= 1)
                            {
                                if (difference[i] >= difference[i - 1])
                                {
                                    if (cash / rubBank[i] > 0)
                                    {
                                        rubWithdrawal[i] = cash / rubBank[i];

                                        listRub[i] -= rubWithdrawal[i];
                                        
                                        cash = cash - (cash / rubBank[i] * rubBank[i]);
                                        
                                    }

                                }


                            }
                            else if (i == 0)
                            {
                                if (cash / rubBank[i] > 0)
                                {
                                    rubWithdrawal[i] = cash / rubBank[i];

                                    listRub[i] -= rubWithdrawal[i];
                                    
                                    cash = cash - (cash / rubBank[i] * rubBank[i]);
                                    
                                }
                            }



                        }
                        else { break; }

                    }
                    





                    for (int i = 0; i < rubWithdrawal.Length; i++)
                    {
                        

                        Console.WriteLine($"{rubNumberList[i]} вычтено {rubWithdrawal[i]} банкнот из {listRub[i]}");
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Остаток - {cash}");
                    Console.ReadLine();
                    Console.Clear();

                banknotesRub[0].hundred = listRub[0];
                banknotesRub[0].twoHundred = listRub[1];
                banknotesRub[0].fiveHundred = listRub[2];
                banknotesRub[0].thousand = listRub[3];
                banknotesRub[0].twoThousand = listRub[4];
                banknotesRub[0].fiveThousand = listRub[5];
                db.SaveChanges();


















            }


            

        }






        //using (ApplicationContext db = new ApplicationContext())
        //{
        //Rub  test = new Rub {hundred=50, twoThousand=50, fiveHundred=50, thousand=50, twoHundred=50, fiveThousand=50};


        //db.Rub.Add(test);
        //db.SaveChanges();
        //Rub test = db.Rub.FirstOrDefault();
        //if (test != null)
        //{
        //    db.Rub.Remove(test);
        //    db.SaveChanges();
        //}

        //var banknotesRub = db.Rub.ToList();
        //Console.WriteLine("Информация о купюрах Rub:");
        //foreach (var r in banknotesRub)
        //{
        //    Console.WriteLine($"'100'\t - {r.hundred}\n'200'\t - {r.twoHundred}\n'500'\t - {r.fiveHundred}\n'1000'\t - {r.thousand}\n'2000'\t - {r.twoThousand}\n'5000'\t - {r.fiveThousand}\n");
        //}

        //var banknotesUsd = db.Usd.ToList();
        //Console.WriteLine("Информация о купюрах Usd:");
        //foreach (var u in banknotesUsd)
        //{
        //    Console.Write($"'1'\t - {u.one}\n'2'\t - {u.two}\n'5'\t - {u.five}\n'10'\t - {u.ten}\n'20'\t - {u.twenty}\n'50'\t - {u.fifty}\n'100'\t - {u.hundred}\n\n");
        //}

        //var banknotesEur = db.Eur.ToList();
        //Console.WriteLine("Информация о купюрах Eur:");
        //foreach (var e in banknotesEur)
        //{
        //    Console.Write($"'5'\t - {e.five}\n'10'\t - {e.ten}\n'20'\t - {e.twenty}\n'50'\t - {e.fifty}\n'100'\t - {e.hundred}\n'200'\t - {e.twoHundred}\n'500'\t - {e.fiveHundred}\n");

        //}





    }
}
