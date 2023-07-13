using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsQuestionAnswer : clsMain
    {
        public int id { get; set; }
        public int questionBankId { get; set; }
        public string choiceCode { get; set; }
        public string choiceName { get; set; }
        public bool isAnswer { get; set; }
        public int manDays { get; set; }
        public int questionEffectId { get; set; }
        public int planningDays { get; set; }
    }
}
