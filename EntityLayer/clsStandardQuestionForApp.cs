using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsStandardQuestionForApp : clsMain
    {
        public int id { get; set; }
        public int appId { get; set; }
        public int questionBankId { get; set; }
        public int questionAnswerId { get; set; }
        public string questionAnswer { get; set; }
    }
}
