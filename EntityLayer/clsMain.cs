using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class clsMain
    {
        public bool active { get; set; }
        public int createdBy { get; set; }
        public DateTime? createdOn { get; set; }
        public int modifiedBy { get; set; }
        public DateTime? modifiedOn { get; set; }
        public int userId { get; set; }
        public string dbName { get; set; }
    }
    public enum enumStationaryType
    {
        Application = 1,
        ClientMaster = 2,
        Quotation = 3,
        Buyer = 4,
        Invoice = 4

    }
}
