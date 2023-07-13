using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public  class clsQuestionControlChoice : clsMain
    {
        public int id { get; set; }
        public int questionBankId { get; set; }
        public int parentQuestionId { get; set; }
        public int questionAnswerId { get; set; }
    }
}
