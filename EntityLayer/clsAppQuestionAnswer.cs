using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsAppQuestionAnswer : clsMain
    { 
        public int id { get; set; }
        public int appId {set;get;}
        public int stdAppQuestionId {set;get;}
        public string choiceCode {set;get;}
        public string choiceName { set; get; }
        public bool isAnswer { set; get; }
    }
}
