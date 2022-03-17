using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class ScreenMessages
    {

        public static void Wellcome()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine($"\t\tДобро пожаловать в банкомат\n\t\tСегодня {now}");
        }

        
            
    }
}
