using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsCurrency : clsMain
    {
        public int  id { get; set; }
        public string currencyName { get; set; }
        public string currencyShortName { get; set; }
        public string symbol { get; set; }
    }
}
