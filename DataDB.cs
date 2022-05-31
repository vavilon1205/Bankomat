using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class Rub
    {
        public int Id { get; set; }
        public int hundred { get; set; }
        public int twoHundred { get; set; }
        public int fiveHundred { get; set; }
        public int thousand { get; set; }
        public int twoThousand { get; set; }
        public int fiveThousand { get; set; }

    }

    public class Usd
    {
        public int Id { get; set; }
        public int one { get; set; }
        public int two { get; set; }
        public int five { get; set; }
        public int ten { get; set; }
        public int twenty { get; set; }
        public int fifty { get; set; }
        public int hundred { get; set; }
    }

    public class Eur
    {
        public int Id { get; set; }
        public int five { get; set; }
        public int ten { get; set; }
        public int twenty { get; set; }
        public int fifty { get; set; }
        public int hundred { get; set; }
        public int twoHundred { get; set; }
        public int fiveHundred { get; set; }
    }
    public class SettingsBankomat
    {
        public int Id { get; set; }
        public string? securyCode { get; set; }
        public string? pathCards { get; set; }
        public string? parthPrintBalanceCard { get; set; }


    }

    
}
