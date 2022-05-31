using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class DbCreateSet
    {
        public static void DbCreateSetValue()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var banknotesRub = db.Rub.ToList();
                var banknotesUsd = db.Usd.ToList();
                var banknotesEur = db.Eur.ToList();
                var bankomatSettings = db.SettingsBankomat.ToList();

                try
                {
                    banknotesRub[0].hundred = 0;
                    banknotesRub[0].twoHundred = 0;
                    banknotesRub[0].fiveHundred = 0;
                    banknotesRub[0].thousand = 0;
                    banknotesRub[0].twoThousand = 0;
                    banknotesRub[0].fiveThousand = 0;

                    banknotesUsd[0].one = 0;
                    banknotesUsd[0].two = 0;
                    banknotesUsd[0].five = 0;
                    banknotesUsd[0].ten = 0;
                    banknotesUsd[0].twenty = 0;
                    banknotesUsd[0].fifty = 0;
                    banknotesUsd[0].hundred = 0;

                    banknotesEur[0].five = 0;
                    banknotesEur[0].ten = 0;
                    banknotesEur[0].twenty = 0;
                    banknotesEur[0].fifty = 0;
                    banknotesEur[0].hundred = 0;
                    banknotesEur[0].twoHundred = 0;
                    banknotesEur[0].fiveHundred = 0;

                    bankomatSettings[0].securyCode = "00";
                    bankomatSettings[0].pathCards = "Cards.txt";
                    bankomatSettings[0].parthPrintBalanceCard = "C:\\Users\\vavil\\OneDrive\\Рабочий стол\\Balance.txt";

                }
                catch (System.ArgumentOutOfRangeException)
                {
                    Rub testRub = new Rub { hundred = 0, twoThousand = 0, fiveHundred = 0, thousand = 0, twoHundred = 0, fiveThousand = 0 };
                    Usd testUsd = new Usd { one = 0, two = 0, five = 0, ten = 0, twenty = 0, fifty = 0, hundred = 0 };
                    Eur testEur = new Eur { five = 0, ten = 0, twenty = 0, fifty = 0, hundred = 0, twoHundred = 0, fiveHundred = 0 };
                    SettingsBankomat testSettingsBankomat = new SettingsBankomat { securyCode = "000", pathCards = "Cards.txt", parthPrintBalanceCard = "BalanceCard.txt" };
                
                    db.Rub.Add(testRub);
                    db.Usd.Add(testUsd);
                    db.Eur.Add(testEur);
                    db.SettingsBankomat.Add(testSettingsBankomat);
                    
                    db.SaveChanges();
                }
            }


        }





    }
}
